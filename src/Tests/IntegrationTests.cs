namespace Tests;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using MimeKit;

using NLog.Config;
using NLog.Targets;

using PSNLog;

using SmtpServer;
using SmtpServer.Authentication;
using SmtpServer.Storage;

using Xunit;

public class IntegrationTests
{
    [Fact]
    public void LoggerWithConsoleTargetShouldWork()
    {
        const string name = "MyLogger";
        const string message = "Hello world!";
        const string layout = "[${level:uppercase=true}] [${logger}] ${message}";
        var result = ((FormattableString)$"[INFO] [{name}] {message}\r\n").ToString(CultureInfo.InvariantCulture);

        var initialSessionState = InitialSessionState.CreateDefault();

        var entry1 = new SessionStateCmdletEntry("New-NLogLoggingConfiguration", typeof(NewLoggingConfigurationCommand), null);
        initialSessionState.Commands.Add(entry1);

        var entry2 = new SessionStateCmdletEntry("New-NLogConsoleTarget", typeof(NewConsoleTargetCommand), null);
        initialSessionState.Commands.Add(entry2);

        var entry3 = new SessionStateCmdletEntry("New-NLogLoggingRule", typeof(NewLoggingRuleCommand), null);
        initialSessionState.Commands.Add(entry3);

        var entry4 = new SessionStateCmdletEntry("Add-NLogLoggingRule", typeof(AddLoggingRuleCommand), null);
        initialSessionState.Commands.Add(entry4);

        var entry5 = new SessionStateCmdletEntry("Add-NLogLoggingConfiguration", typeof(AddLoggingConfigurationCommand), null);
        initialSessionState.Commands.Add(entry5);

        var entry6 = new SessionStateCmdletEntry("Get-NLogLogger", typeof(GetLoggerCommand), null);
        initialSessionState.Commands.Add(entry6);

        var entry7 = new SessionStateCmdletEntry("Stop-NLogLogging", typeof(StopLoggingCommand), null);
        initialSessionState.Commands.Add(entry7);

        using var runSpace = RunspaceFactory.CreateRunspace(initialSessionState);
        using var powerShell = PowerShell.Create();

        runSpace.Open();
        powerShell.Runspace = runSpace;

        powerShell
            .AddStatement()
            .AddCommand("New-NLogLoggingConfiguration");

        var configuration = powerShell.Invoke<LoggingConfiguration>().Single();
        Assert.False(powerShell.HadErrors);

        powerShell.Commands.Clear();

        powerShell
            .AddStatement()
            .AddCommand("New-NLogConsoleTarget")
            .AddParameter(nameof(NewConsoleTargetCommand.Layout), layout)
            .AddParameter(nameof(NewConsoleTargetCommand.Name), "ConsoleTarget");

        var target = powerShell.Invoke<ConsoleTarget>().Single();
        Assert.False(powerShell.HadErrors);

        powerShell.Commands.Clear();

        powerShell
            .AddStatement()
            .AddCommand("New-NLogLoggingRule")
            .AddParameter(nameof(NewLoggingRuleCommand.Target), target)
            .AddParameter(nameof(NewLoggingRuleCommand.Name), "ConsoleRule")
            .AddParameter(nameof(NewLoggingRuleCommand.LoggerNamePattern), "*")
            .AddParameter(nameof(NewLoggingRuleCommand.MinLevel), NLog.LogLevel.Trace)
            .AddParameter(nameof(NewLoggingRuleCommand.MaxLevel), NLog.LogLevel.Fatal)
            .AddCommand("Add-NLogLoggingRule")
            .AddParameter(nameof(AddLoggingRuleCommand.Configuration), configuration);

        powerShell
            .AddStatement()
            .AddCommand("Add-NLogLoggingConfiguration")
            .AddParameter(nameof(AddLoggingConfigurationCommand.Configuration), configuration);

        powerShell
            .AddStatement()
            .AddCommand("Get-NLogLogger")
            .AddParameter(nameof(GetLoggerCommand.Name), name)
            .AddCommand("Set-Variable")
            .AddParameter("Name", "logger");

        powerShell
            .AddStatement()
            .AddScript(
                ((FormattableString)$$"""
                $originalOut = [Console]::Out
                $writer = [IO.StringWriter]::new()
                try
                {
                   [Console]::SetOut($writer)
                   $logger.Info('{{message}}')
                }
                finally
                {
                   [Console]::SetOut($originalOut)
                }

                $writer.ToString()
                """).ToString(CultureInfo.InvariantCulture));

        powerShell
            .AddStatement()
            .AddCommand("Stop-NLogLogging");

        var results = powerShell.Invoke<string>();

        Assert.False(powerShell.HadErrors);
        Assert.Single(results);
        Assert.Equal(result, results[0], StringComparer.Ordinal);
    }

    [Fact]
    public async Task LoggerWithMailTargetShouldWork()
    {
        const string sender = "sender@domain.com";
        const string recipient = "recipient@domain.com";
        const string server = "localhost";
        const int port = 25000;
        const string name = "MyLogger";
        const string message = "Hello world!";
        var result = ((FormattableString)$"{message}\r\n").ToString(CultureInfo.InvariantCulture);

        using var cancellationTokenSource = new CancellationTokenSource();

        var messages = new List<MimeMessage>();
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IUserAuthenticator>(new TestUserAuthenticator())
            .AddSingleton<IMailboxFilter>(new TestMailboxFilter())
            .AddSingleton<IMessageStore>(new TestMessageStore(messages))
            .BuildServiceProvider();

        var options = new SmtpServerOptionsBuilder()
            .ServerName(server)
            .Endpoint(builder => builder.Endpoint(new IPEndPoint(IPAddress.Loopback, port)))
            .Build();

        var smtpServer = new SmtpServer(options, serviceProvider);
        smtpServer.SessionFaulted += (_, args) =>
        {
            Debug.WriteLine(args.Exception);
            cancellationTokenSource.Cancel();
        };

        var smtpServerTask = smtpServer.StartAsync(cancellationTokenSource.Token);

        var initialSessionState = InitialSessionState.CreateDefault();

        var entry1 = new SessionStateCmdletEntry("New-NLogLoggingConfiguration", typeof(NewLoggingConfigurationCommand), null);
        initialSessionState.Commands.Add(entry1);

        var entry2 = new SessionStateCmdletEntry("New-NLogMailTarget", typeof(NewMailTargetCommand), null);
        initialSessionState.Commands.Add(entry2);

        var entry3 = new SessionStateCmdletEntry("New-NLogLoggingRule", typeof(NewLoggingRuleCommand), null);
        initialSessionState.Commands.Add(entry3);

        var entry4 = new SessionStateCmdletEntry("Add-NLogLoggingRule", typeof(AddLoggingRuleCommand), null);
        initialSessionState.Commands.Add(entry4);

        var entry5 = new SessionStateCmdletEntry("Add-NLogLoggingConfiguration", typeof(AddLoggingConfigurationCommand), null);
        initialSessionState.Commands.Add(entry5);

        var entry6 = new SessionStateCmdletEntry("Get-NLogLogger", typeof(GetLoggerCommand), null);
        initialSessionState.Commands.Add(entry6);

        var entry7 = new SessionStateCmdletEntry("Stop-NLogLogging", typeof(StopLoggingCommand), null);
        initialSessionState.Commands.Add(entry7);

        using var runSpace = RunspaceFactory.CreateRunspace(initialSessionState);
        using var powerShell = PowerShell.Create();

        runSpace.Open();
        powerShell.Runspace = runSpace;

        powerShell
            .AddStatement()
            .AddCommand("New-NLogLoggingConfiguration");

        var configuration = powerShell.Invoke<LoggingConfiguration>().Single();
        Assert.False(powerShell.HadErrors);

        powerShell.Commands.Clear();

        powerShell
            .AddStatement()
            .AddCommand("New-NLogMailTarget")
            .AddParameter(nameof(NewMailTargetCommand.From), sender)
            .AddParameter(nameof(NewMailTargetCommand.To), recipient)
            .AddParameter(nameof(NewMailTargetCommand.SmtpPort), port)
            .AddParameter(nameof(NewMailTargetCommand.SmtpServer), server)
            .AddParameter(nameof(NewMailTargetCommand.Name), "MailTarget");

        var target = powerShell.Invoke<MailTarget>().Single();
        Assert.False(powerShell.HadErrors);

        powerShell.Commands.Clear();

        powerShell
            .AddStatement()
            .AddCommand("New-NLogLoggingRule")
            .AddParameter(nameof(NewLoggingRuleCommand.Target), target)
            .AddParameter(nameof(NewLoggingRuleCommand.Name), "MailRule")
            .AddParameter(nameof(NewLoggingRuleCommand.LoggerNamePattern), "*")
            .AddParameter(nameof(NewLoggingRuleCommand.MinLevel), NLog.LogLevel.Trace)
            .AddParameter(nameof(NewLoggingRuleCommand.MaxLevel), NLog.LogLevel.Fatal)
            .AddCommand("Add-NLogLoggingRule")
            .AddParameter(nameof(AddLoggingRuleCommand.Configuration), configuration);

        powerShell
            .AddStatement()
            .AddCommand("Add-NLogLoggingConfiguration")
            .AddParameter(nameof(AddLoggingConfigurationCommand.Configuration), configuration);

        powerShell
            .AddStatement()
            .AddCommand("Get-NLogLogger")
            .AddParameter(nameof(GetLoggerCommand.Name), name)
            .AddCommand("Set-Variable")
            .AddParameter("Name", "logger");

        powerShell
            .AddStatement()
            .AddScript(((FormattableString)$"$logger.Info('{message}')").ToString(CultureInfo.InvariantCulture));

        powerShell
            .AddStatement()
            .AddCommand("Stop-NLogLogging");

        powerShell.Invoke();

        Assert.False(powerShell.HadErrors);

        var stopWatch = Stopwatch.StartNew();
        while (stopWatch.ElapsedMilliseconds < 5000 && messages.Count == 0)
        {
            await Task.Delay(100, cancellationTokenSource.Token);
            Debug.WriteLine($"Messages Count: {messages.Count}");
        }

        stopWatch.Stop();

        Assert.Single(messages);
        Assert.Equal(result, messages[0].TextBody, StringComparer.Ordinal);

        smtpServer.Shutdown();
        await smtpServerTask;
    }

    [Fact]
    public void LoggerWithFileTargetShouldWork()
    {
        const string name = "MyLogger";
        const string message = "Hello world!";
        const string layout = "[${level:uppercase=true}] [${logger}] ${message}";
        var result = ((FormattableString)$"[INFO] [{name}] {message}").ToString(CultureInfo.InvariantCulture);

        var initialSessionState = InitialSessionState.CreateDefault();

        var entry1 = new SessionStateCmdletEntry("New-NLogLoggingConfiguration", typeof(NewLoggingConfigurationCommand), null);
        initialSessionState.Commands.Add(entry1);

        var entry2 = new SessionStateCmdletEntry("New-NLogFileTarget", typeof(NewFileTargetCommand), null);
        initialSessionState.Commands.Add(entry2);

        var entry3 = new SessionStateCmdletEntry("New-NLogLoggingRule", typeof(NewLoggingRuleCommand), null);
        initialSessionState.Commands.Add(entry3);

        var entry4 = new SessionStateCmdletEntry("Add-NLogLoggingRule", typeof(AddLoggingRuleCommand), null);
        initialSessionState.Commands.Add(entry4);

        var entry5 = new SessionStateCmdletEntry("Add-NLogLoggingConfiguration", typeof(AddLoggingConfigurationCommand), null);
        initialSessionState.Commands.Add(entry5);

        var entry6 = new SessionStateCmdletEntry("Get-NLogLogger", typeof(GetLoggerCommand), null);
        initialSessionState.Commands.Add(entry6);

        var entry7 = new SessionStateCmdletEntry("Stop-NLogLogging", typeof(StopLoggingCommand), null);
        initialSessionState.Commands.Add(entry7);

        using var runSpace = RunspaceFactory.CreateRunspace(initialSessionState);
        using var powerShell = PowerShell.Create();

        runSpace.Open();
        powerShell.Runspace = runSpace;

        var path = Path.GetTempFileName();
        string[] results;
        try
        {
            powerShell
                .AddStatement()
                .AddCommand("New-NLogLoggingConfiguration");

            var configuration = powerShell.Invoke<LoggingConfiguration>().Single();
            Assert.False(powerShell.HadErrors);

            powerShell.Commands.Clear();

            powerShell
                .AddStatement()
                .AddCommand("New-NLogFileTarget")
                .AddParameter(nameof(NewFileTargetCommand.AutoFlush), true)
                .AddParameter(nameof(NewFileTargetCommand.FileName), path)
                .AddParameter(nameof(NewFileTargetCommand.Layout), layout)
                .AddParameter(nameof(NewFileTargetCommand.Name), "FileTarget");

            var target = powerShell.Invoke<FileTarget>().Single();
            Assert.False(powerShell.HadErrors);

            powerShell.Commands.Clear();

            powerShell
                .AddStatement()
                .AddCommand("New-NLogLoggingRule")
                .AddParameter(nameof(NewLoggingRuleCommand.Target), target)
                .AddParameter(nameof(NewLoggingRuleCommand.Name), "FileRule")
                .AddParameter(nameof(NewLoggingRuleCommand.LoggerNamePattern), "*")
                .AddParameter(nameof(NewLoggingRuleCommand.MinLevel), NLog.LogLevel.Trace)
                .AddParameter(nameof(NewLoggingRuleCommand.MaxLevel), NLog.LogLevel.Fatal)
                .AddCommand("Add-NLogLoggingRule")
                .AddParameter(nameof(AddLoggingRuleCommand.Configuration), configuration);

            powerShell
                .AddStatement()
                .AddCommand("Add-NLogLoggingConfiguration")
                .AddParameter(nameof(AddLoggingConfigurationCommand.Configuration), configuration);

            powerShell
                .AddStatement()
                .AddCommand("Get-NLogLogger")
                .AddParameter(nameof(GetLoggerCommand.Name), name)
                .AddCommand("Set-Variable")
                .AddParameter("Name", "logger");

            powerShell
                .AddStatement()
                .AddScript(((FormattableString)$"$logger.Info('{message}')").ToString(CultureInfo.InvariantCulture));

            powerShell
                .AddStatement()
                .AddCommand("Stop-NLogLogging");

            powerShell.Invoke();

            results = File.ReadAllLines(path);
        }
        finally
        {
            File.Delete(path);
        }

        Assert.False(powerShell.HadErrors);
        Assert.Single(results);
        Assert.Equal(result, results[0], StringComparer.Ordinal);
    }
}
namespace Tests;

using System.Globalization;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

using NLog.Config;
using NLog.Targets;

using PSNLog;

[TestClass]
public class IntegrationTests
{
    [TestMethod]
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
        Assert.IsFalse(powerShell.HadErrors);

        powerShell.Commands.Clear();

        powerShell
            .AddStatement()
            .AddCommand("New-NLogConsoleTarget")
            .AddParameter(nameof(NewConsoleTargetCommand.Layout), layout)
            .AddParameter(nameof(NewConsoleTargetCommand.Name), "ConsoleTarget");

        var target = powerShell.Invoke<ConsoleTarget>().Single();
        Assert.IsFalse(powerShell.HadErrors);

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

        Assert.IsFalse(powerShell.HadErrors);
        Assert.ContainsSingle(results);
        Assert.AreEqual(result, results[0], StringComparer.Ordinal);
    }

    [TestMethod]
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
            Assert.IsFalse(powerShell.HadErrors);

            powerShell.Commands.Clear();

            powerShell
                .AddStatement()
                .AddCommand("New-NLogFileTarget")
                .AddParameter(nameof(NewFileTargetCommand.AutoFlush), true)
                .AddParameter(nameof(NewFileTargetCommand.FileName), path)
                .AddParameter(nameof(NewFileTargetCommand.Layout), layout)
                .AddParameter(nameof(NewFileTargetCommand.Name), "FileTarget");

            var target = powerShell.Invoke<FileTarget>().Single();
            Assert.IsFalse(powerShell.HadErrors);

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

        Assert.IsFalse(powerShell.HadErrors);
        Assert.ContainsSingle(results);
        Assert.AreEqual(result, results[0], StringComparer.Ordinal);
    }
}
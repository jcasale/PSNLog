namespace PSNLog;

using System;
using System.Management.Automation;

using NLog;
using NLog.Config;
using NLog.Targets;

[Cmdlet(VerbsCommon.New, "NLogBasicLogger")]
[OutputType(typeof(LoggingConfiguration))]
public class NewBasicLoggerCommand : PSCmdlet
{
    private const string Layout = "[${longDate}] " +
        "[${logger:shortName=false}] " +
        "[${uppercase:${level}}] " +
        "${message}" +
        "${onException:${newLine}${exception:format=toString:innerFormat=toString,Data:exceptionDataSeparator=\r\n:maxInnerExceptionLevel=10}}";

    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The name of the logger.")]
    [ValidateNotNullOrEmpty]
    public string Name { get; set; }

    [Parameter(
        Position = 1,
        Mandatory = true,
        ValueFromPipeline = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The name of the log file.")]
    [ValidateNotNullOrEmpty]
    public string Path { get; set; }

    protected override void ProcessRecord()
    {
        var configuration = new LoggingConfiguration();

        var file = new FileTarget(nameof(FileTarget))
        {
            FileName = Path,
            Layout = Layout,
            OpenFileCacheTimeout = 30
        };

        var console = new ConsoleTarget(nameof(ConsoleTarget))
        {
            Layout = Layout
        };

        configuration.AddRule(LogLevel.Trace, LogLevel.Fatal, console);
        configuration.AddRule(LogLevel.Trace, LogLevel.Fatal, file);

        if (LogManager.Configuration is not null)
        {
            ThrowTerminatingError(new ErrorRecord(
                new InvalidOperationException("A logging configuration already exists."),
                "LoggingConfigurationAlreadyExists",
                ErrorCategory.InvalidOperation,
                null));

            return;
        }

        LogManager.Configuration = configuration;

        var logger = LogManager.GetLogger(Name);

        WriteObject(logger);
    }
}
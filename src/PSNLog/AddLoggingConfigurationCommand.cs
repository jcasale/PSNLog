namespace PSNLog;

using System;
using System.Management.Automation;

using NLog;
using NLog.Config;

[Cmdlet(VerbsCommon.Add, "NLogLoggingConfiguration")]
[OutputType(typeof(LoggingConfiguration))]
public class AddLoggingConfigurationCommand : PSCmdlet
{
    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Specifies the configuration to apply.")]
    [ValidateNotNull]
    public LoggingConfiguration Configuration { get; set; }

    [Parameter(HelpMessage = "Returns the configuration object. By default, this cmdlet does not generate any output.")]
    public SwitchParameter PassThru { get; set; }

    protected override void ProcessRecord()
    {
        if (LogManager.Configuration is not null)
        {
            ThrowTerminatingError(new ErrorRecord(
                new InvalidOperationException("A logging configuration already exists."),
                "LoggingConfigurationAlreadyExists",
                ErrorCategory.InvalidOperation,
                null));

            return;
        }

        LogManager.Configuration = Configuration;

        if (PassThru.IsPresent)
        {
            WriteObject(Configuration);
        }
    }
}
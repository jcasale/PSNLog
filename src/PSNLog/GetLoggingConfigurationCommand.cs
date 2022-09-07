namespace PSNLog;

using System.Management.Automation;
using NLog;
using NLog.Config;

[Cmdlet(VerbsCommon.Get, "NLogLoggingConfiguration")]
[OutputType(typeof(LoggingConfiguration))]
public class GetLoggingConfigurationCommand : PSCmdlet
{
    protected override void ProcessRecord()
    {
        var configuration = LogManager.Configuration;

        if (configuration is null)
        {
            this.ThrowTerminatingError(new ErrorRecord(
                new ItemNotFoundException("A logging configuration was not found."),
                "LoggingConfigurationNotFound",
                ErrorCategory.ObjectNotFound,
                null));

            return;
        }

        this.WriteObject(configuration);
    }
}
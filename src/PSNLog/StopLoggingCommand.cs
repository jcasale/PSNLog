namespace PSNLog;

using System.Management.Automation;

using NLog;

[Cmdlet(VerbsLifecycle.Stop, "NLogLogging")]
public class StopLoggingCommand : PSCmdlet
{
    protected override void ProcessRecord()
    {
        LogManager.Shutdown();
        LogManager.Configuration = null;
    }
}
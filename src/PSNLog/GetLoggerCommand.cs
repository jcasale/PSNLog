namespace PSNLog;

using System.Management.Automation;

using NLog;

[Cmdlet(VerbsCommon.Get, "NLogLogger")]
[OutputType(typeof(Logger))]
public class GetLoggerCommand : PSCmdlet
{
    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Specifies the name of the logger.")]
    [ValidateNotNullOrEmpty]
    public string Name { get; set; }

    protected override void ProcessRecord()
    {
        var logger = LogManager.GetLogger(this.Name);

        this.WriteObject(logger);
    }
}
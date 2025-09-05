namespace PSNLog;

using System.Management.Automation;

using NLog.Config;
using NLog.Targets;

[Cmdlet(VerbsCommon.Add, "NLogTarget")]
[OutputType(typeof(LoggingConfiguration))]
public class AddTargetCommand : PSCmdlet
{
    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Specifies the target to add.")]
    [ValidateNotNull]
    public Target Target { get; set; }

    [Parameter(
        Position = 1,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Specifies the configuration to update.")]
    [ValidateNotNull]
    public LoggingConfiguration Configuration { get; set; }

    [Parameter(HelpMessage = "Returns the configuration object. By default, this cmdlet does not generate any output.")]
    public SwitchParameter PassThru { get; set; }

    protected override void ProcessRecord()
    {
        this.Configuration.AddTarget(this.Target);

        if (this.PassThru.IsPresent)
        {
            this.WriteObject(this.Configuration);
        }
    }
}
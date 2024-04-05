namespace PSNLog;

using System;
using System.Management.Automation;
using NLog.Config;
using NLog.Targets;

[Cmdlet(VerbsCommon.Remove, "NLogTarget")]
[OutputType(typeof(LoggingConfiguration))]
public class RemoveTargetCommand : PSCmdlet
{
    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(Target),
        HelpMessage = "Specifies the target to remove.")]
    [ValidateNotNull]
    public Target Target { get; set; }

    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(Name),
        HelpMessage = "Specifies the name of the target to remove.")]
    [ValidateNotNullOrEmpty]
    public string Name { get; set; }

    [Parameter(
        Position = 1,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Specifies the configuration to modify.")]
    [ValidateNotNull]
    public LoggingConfiguration Configuration { get; set; }

    [Parameter(HelpMessage = "Returns the configuration object. By default, this cmdlet does not generate any output.")]
    public SwitchParameter PassThru { get; set; }

    protected override void ProcessRecord()
    {
        switch (this.ParameterSetName)
        {
            case nameof(this.Target):

                if (string.IsNullOrWhiteSpace(this.Target.Name))
                {
                    this.ThrowTerminatingError(new ErrorRecord(
                        new ItemNotFoundException("The target is unnamed."),
                        "TargetNameMissing",
                        ErrorCategory.InvalidOperation,
                        null));

                    return;
                }

                this.Configuration.RemoveTarget(this.Target.Name);

                break;

            case nameof(this.Name):

                this.Configuration.RemoveTarget(this.Name);

                break;

            default:
                throw new InvalidOperationException("Unknown parameter set.");
        }

        if (this.PassThru.IsPresent)
        {
            this.WriteObject(this.Configuration);
        }
    }
}
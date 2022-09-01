namespace PSNLog;

using System.Management.Automation;
using NLog.Config;

[Cmdlet(VerbsCommon.Add, "NLogLoggingRule")]
[OutputType(typeof(LoggingConfiguration))]
public class AddLoggingRuleCommand : PSCmdlet
{
    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Specifies the rule to add.")]
    [ValidateNotNull]
    public LoggingRule Rule { get; set; }

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
        this.Configuration.LoggingRules.Add(this.Rule);

        if (this.PassThru.IsPresent)
        {
            this.WriteObject(this.Configuration);
        }
    }
}
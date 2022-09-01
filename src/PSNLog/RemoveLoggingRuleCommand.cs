namespace PSNLog;

using System;
using System.Management.Automation;
using NLog.Config;

[Cmdlet(VerbsCommon.Remove, "NLogLoggingRule")]
[OutputType(typeof(LoggingConfiguration))]
public class RemoveLoggingRuleCommand : PSCmdlet
{
    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(Rule),
        HelpMessage = "Specifies the rule to remove.")]
    [ValidateNotNull]
    public LoggingRule Rule { get; set; }

    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(Name),
        HelpMessage = "Specifies the name of the rule to remove.")]
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

    protected override void ProcessRecord()
    {
        var removed = this.ParameterSetName switch
        {
            nameof(this.Rule) => this.Configuration.RemoveRuleByName(this.Rule.RuleName),
            nameof(this.Name) => this.Configuration.RemoveRuleByName(this.Name),
            _ => throw new InvalidOperationException("Unknown parameter set.")
        };

        if (!removed)
        {
            this.ThrowTerminatingError(new ErrorRecord(
                new ItemNotFoundException("The logging rule was not found."),
                "LoggingRuleNotFound",
                ErrorCategory.ObjectNotFound,
                null));

            return;
        }

        this.WriteObject(this.Configuration);
    }
}
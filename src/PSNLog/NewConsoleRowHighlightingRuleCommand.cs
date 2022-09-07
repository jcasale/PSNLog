namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogConsoleRowHighlightingRule")]
[OutputType(typeof(NLog.Targets.ConsoleRowHighlightingRule))]
public class NewConsoleRowHighlightingRuleCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the background color.")]
    public NLog.Targets.ConsoleOutputColor? BackgroundColor { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the condition that must be met in order to set the specified foreground and background color.")]
    public NLog.Conditions.ConditionExpression Condition { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the foreground color.")]
    public NLog.Targets.ConsoleOutputColor? ForegroundColor { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.ConsoleRowHighlightingRule();

        if (this.BackgroundColor.HasValue)
        {
            instance.BackgroundColor = this.BackgroundColor.Value;
        }

        if (this.Condition is not null)
        {
            instance.Condition = this.Condition;
        }

        if (this.ForegroundColor.HasValue)
        {
            instance.ForegroundColor = this.ForegroundColor.Value;
        }

        this.WriteObject(instance);
    }
}

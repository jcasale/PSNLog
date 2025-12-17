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

        if (BackgroundColor.HasValue)
        {
            instance.BackgroundColor = BackgroundColor.Value;
        }

        if (Condition is not null)
        {
            instance.Condition = Condition;
        }

        if (ForegroundColor.HasValue)
        {
            instance.ForegroundColor = ForegroundColor.Value;
        }

        WriteObject(instance);
    }
}

namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogConsoleWordHighlightingRule")]
[OutputType(typeof(NLog.Targets.ConsoleWordHighlightingRule))]
public class NewConsoleWordHighlightingRuleCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the background color.")]
    public NLog.Targets.ConsoleOutputColor BackgroundColor { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the condition that must be met before scanning the row for highlight of words.")]
    public NLog.Conditions.ConditionExpression Condition { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the foreground color.")]
    public NLog.Targets.ConsoleOutputColor ForegroundColor { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to ignore case when comparing texts.")]
    public bool IgnoreCase { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the text to be matched for Highlighting.")]
    public string Text { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to match whole words only.")]
    public bool WholeWords { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the list of words to be matched for Highlighting.")]
    public string[] Words { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.ConsoleWordHighlightingRule();

        if (MyInvocation.BoundParameters.ContainsKey(nameof(BackgroundColor)))
        {
            instance.BackgroundColor = BackgroundColor;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Condition)))
        {
            instance.Condition = Condition;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(ForegroundColor)))
        {
            instance.ForegroundColor = ForegroundColor;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(IgnoreCase)))
        {
            instance.IgnoreCase = IgnoreCase;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Text)))
        {
            instance.Text = Text;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(WholeWords)))
        {
            instance.WholeWords = WholeWords;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Words)))
        {
            if (Words is { Length: > 0 })
            {
                instance.Words = [.. Words];
            }
        }

        WriteObject(instance);
    }
}

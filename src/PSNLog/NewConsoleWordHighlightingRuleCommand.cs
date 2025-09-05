namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogConsoleWordHighlightingRule")]
[OutputType(typeof(NLog.Targets.ConsoleWordHighlightingRule))]
public class NewConsoleWordHighlightingRuleCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the background color.")]
    public NLog.Targets.ConsoleOutputColor? BackgroundColor { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the condition that must be met before scanning the row for highlight of words.")]
    public NLog.Conditions.ConditionExpression Condition { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the foreground color.")]
    public NLog.Targets.ConsoleOutputColor? ForegroundColor { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to ignore case when comparing texts.")]
    public bool? IgnoreCase { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the text to be matched for Highlighting.")]
    public string Text { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to match whole words only.")]
    public bool? WholeWords { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the list of words to be matched for Highlighting.")]
    public string[] Words { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.ConsoleWordHighlightingRule();

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

        if (IgnoreCase.HasValue)
        {
            instance.IgnoreCase = IgnoreCase.Value;
        }

        if (Text is not null)
        {
            instance.Text = Text;
        }

        if (WholeWords.HasValue)
        {
            instance.WholeWords = WholeWords.Value;
        }

        if (Words is { Length: > 0 })
        {
            foreach (var item in Words)
            {
                instance.Words.Add(item);
            }
        }

        WriteObject(instance);
    }
}

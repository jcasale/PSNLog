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
        HelpMessage = "Compile the ? This can improve the performance, but at the costs of more memory usage. If false, the Regex Cache is used.")]
    public bool? CompileRegex { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the condition that must be met before scanning the row for highlight of words")]
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
        HelpMessage = "Gets or sets the regular expression to be matched. You must specify either text or regex.")]
    public string Regex { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the text to be matched. You must specify either text or regex.")]
    public string Text { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to match whole words only.")]
    public bool? WholeWords { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.ConsoleWordHighlightingRule();

        if (this.BackgroundColor.HasValue)
        {
            instance.BackgroundColor = this.BackgroundColor.Value;
        }

        if (this.CompileRegex.HasValue)
        {
            instance.CompileRegex = this.CompileRegex.Value;
        }

        if (this.Condition is not null)
        {
            instance.Condition = this.Condition;
        }

        if (this.ForegroundColor.HasValue)
        {
            instance.ForegroundColor = this.ForegroundColor.Value;
        }

        if (this.IgnoreCase.HasValue)
        {
            instance.IgnoreCase = this.IgnoreCase.Value;
        }

        if (this.Regex is not null)
        {
            instance.Regex = this.Regex;
        }

        if (this.Text is not null)
        {
            instance.Text = this.Text;
        }

        if (this.WholeWords.HasValue)
        {
            instance.WholeWords = this.WholeWords.Value;
        }

        this.WriteObject(instance);
    }
}

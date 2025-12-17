namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogColoredConsoleTarget")]
[OutputType(typeof(NLog.Targets.ColoredConsoleTarget))]
public class NewColoredConsoleTargetCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to auto-flush after M:System.Console.WriteLine.")]
    public bool? AutoFlush { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to auto-check if the console is available. - Disables console writing if Environment.UserInteractive = false (Windows Service) - Disables console writing if Console Standard Input is not available (Non-Console-App).")]
    public bool? DetectConsoleAvailable { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to auto-check if the console has been redirected to file - Disables coloring logic when System.Console.IsOutputRedirected = true.")]
    public bool? DetectOutputRedirected { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Enables output using ANSI Color Codes.")]
    public bool? EnableAnsiOutput { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The encoding for writing messages to the T:System.Console.")]
    public System.Text.Encoding Encoding { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the footer.")]
    public NLog.Layouts.Layout Footer { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the header.")]
    public NLog.Layouts.Layout Header { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the layout used to format log messages.")]
    public NLog.Layouts.Layout Layout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the target.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Support NO_COLOR=1 environment variable. See also https://no-color.org/.")]
    public NLog.Layouts.Layout<bool> NoColor { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets the row highlighting rules.")]
    public NLog.Targets.ConsoleRowHighlightingRule[] RowHighlightingRules { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to send the log messages to the standard error instead of the standard output.")]
    public NLog.Layouts.Layout<bool> StdErr { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to use default row highlighting rules.")]
    public bool? UseDefaultRowHighlightingRules { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets the word highlighting rules.")]
    public NLog.Targets.ConsoleWordHighlightingRule[] WordHighlightingRules { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.ColoredConsoleTarget();

        if (AutoFlush.HasValue)
        {
            instance.AutoFlush = AutoFlush.Value;
        }

        if (DetectConsoleAvailable.HasValue)
        {
            instance.DetectConsoleAvailable = DetectConsoleAvailable.Value;
        }

        if (DetectOutputRedirected.HasValue)
        {
            instance.DetectOutputRedirected = DetectOutputRedirected.Value;
        }

        if (EnableAnsiOutput.HasValue)
        {
            instance.EnableAnsiOutput = EnableAnsiOutput.Value;
        }

        if (Encoding is not null)
        {
            instance.Encoding = Encoding;
        }

        if (Footer is not null)
        {
            instance.Footer = Footer;
        }

        if (Header is not null)
        {
            instance.Header = Header;
        }

        if (Layout is not null)
        {
            instance.Layout = Layout;
        }

        if (Name is not null)
        {
            instance.Name = Name;
        }

        if (NoColor is not null)
        {
            instance.NoColor = NoColor;
        }

        if (RowHighlightingRules is { Length: > 0 })
        {
            foreach (var item in RowHighlightingRules)
            {
                instance.RowHighlightingRules.Add(item);
            }
        }

        if (StdErr is not null)
        {
            instance.StdErr = StdErr;
        }

        if (UseDefaultRowHighlightingRules.HasValue)
        {
            instance.UseDefaultRowHighlightingRules = UseDefaultRowHighlightingRules.Value;
        }

        if (WordHighlightingRules is { Length: > 0 })
        {
            foreach (var item in WordHighlightingRules)
            {
                instance.WordHighlightingRules.Add(item);
            }
        }

        WriteObject(instance);
    }
}

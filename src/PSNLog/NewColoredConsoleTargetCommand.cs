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
        HelpMessage = "Gets or sets a value indicating whether to auto-check if the console is available. - Disables console writing if Environment.UserInteractive = False (Windows Service) - Disables console writing if Console Standard Input is not available (Non-Console-App).")]
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
        HelpMessage = "Gets the row highlighting rules.")]
    public NLog.Targets.ConsoleRowHighlightingRule[] RowHighlightingRules { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to send the log messages to the standard error instead of the standard output.")]
    public bool? StdErr { get; set; }

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

        if (this.AutoFlush.HasValue)
        {
            instance.AutoFlush = this.AutoFlush.Value;
        }

        if (this.DetectConsoleAvailable.HasValue)
        {
            instance.DetectConsoleAvailable = this.DetectConsoleAvailable.Value;
        }

        if (this.DetectOutputRedirected.HasValue)
        {
            instance.DetectOutputRedirected = this.DetectOutputRedirected.Value;
        }

        if (this.EnableAnsiOutput.HasValue)
        {
            instance.EnableAnsiOutput = this.EnableAnsiOutput.Value;
        }

        if (this.Encoding is not null)
        {
            instance.Encoding = this.Encoding;
        }

        if (this.Footer is not null)
        {
            instance.Footer = this.Footer;
        }

        if (this.Header is not null)
        {
            instance.Header = this.Header;
        }

        if (this.Layout is not null)
        {
            instance.Layout = this.Layout;
        }

        if (this.Name is not null)
        {
            instance.Name = this.Name;
        }

        if (this.RowHighlightingRules is {Length: > 0})
        {
            foreach (var item in this.RowHighlightingRules)
            {
                instance.RowHighlightingRules.Add(item);
            }
        }

        if (this.StdErr.HasValue)
        {
            instance.StdErr = this.StdErr.Value;
        }

        if (this.UseDefaultRowHighlightingRules.HasValue)
        {
            instance.UseDefaultRowHighlightingRules = this.UseDefaultRowHighlightingRules.Value;
        }

        if (this.WordHighlightingRules is {Length: > 0})
        {
            foreach (var item in this.WordHighlightingRules)
            {
                instance.WordHighlightingRules.Add(item);
            }
        }

        this.WriteObject(instance);
    }
}

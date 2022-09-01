namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogConsoleTarget")]
[OutputType(typeof(NLog.Targets.ConsoleTarget))]
public class NewConsoleTargetCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to auto-flush after")]
    public bool? AutoFlush { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to auto-check if the console is available - Disables console writing if Environment.UserInteractive = False (Windows Service) - Disables console writing if Console Standard Input is not available (Non-Console-App)")]
    public bool? DetectConsoleAvailable { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The encoding for writing messages to the .")]
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
        HelpMessage = "Gets or sets a value indicating whether to send the log messages to the standard error instead of the standard output.")]
    public bool? StdErr { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets whether to activate internal buffering to allow batch writing, instead of using")]
    public bool? WriteBuffer { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.ConsoleTarget();

        if (this.AutoFlush.HasValue)
        {
            instance.AutoFlush = this.AutoFlush.Value;
        }

        if (this.DetectConsoleAvailable.HasValue)
        {
            instance.DetectConsoleAvailable = this.DetectConsoleAvailable.Value;
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

        if (this.StdErr.HasValue)
        {
            instance.StdErr = this.StdErr.Value;
        }

        if (this.WriteBuffer.HasValue)
        {
            instance.WriteBuffer = this.WriteBuffer.Value;
        }

        this.WriteObject(instance);
    }
}

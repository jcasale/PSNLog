namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogConsoleTarget")]
[OutputType(typeof(NLog.Targets.ConsoleTarget))]
public class NewConsoleTargetCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to auto-flush after M:System.Console.WriteLine.")]
    public bool AutoFlush { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to auto-check if the console is available - Disables console writing if Environment.UserInteractive = false (Windows Service) - Disables console writing if Console Standard Input is not available (Non-Console-App).")]
    public bool DetectConsoleAvailable { get; set; }

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
        HelpMessage = "Gets or sets whether to force M:System.Console.WriteLine (slower) instead of the faster internal buffering.")]
    public bool ForceWriteLine { get; set; }

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
    public NLog.Layouts.Layout<bool> StdErr { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.ConsoleTarget();

        if (MyInvocation.BoundParameters.ContainsKey(nameof(AutoFlush)))
        {
            instance.AutoFlush = AutoFlush;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(DetectConsoleAvailable)))
        {
            instance.DetectConsoleAvailable = DetectConsoleAvailable;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Encoding)))
        {
            instance.Encoding = Encoding;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Footer)))
        {
            instance.Footer = Footer;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(ForceWriteLine)))
        {
            instance.ForceWriteLine = ForceWriteLine;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Header)))
        {
            instance.Header = Header;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Layout)))
        {
            instance.Layout = Layout;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
        {
            instance.Name = Name;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(StdErr)))
        {
            instance.StdErr = StdErr;
        }

        WriteObject(instance);
    }
}

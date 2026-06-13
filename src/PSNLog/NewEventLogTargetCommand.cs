namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogEventLogTarget")]
[OutputType(typeof(NLog.Targets.EventLogTarget))]
public class NewEventLogTargetCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the layout that renders event Category.")]
    public NLog.Layouts.Layout<short> Category { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Optional entry type. When not set, or when not convertible to T:System.Diagnostics.EventLogEntryType then determined by T:NLog.LogLevel.")]
    public NLog.Layouts.Layout<System.Diagnostics.EventLogEntryType> EntryType { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the layout that renders event ID.")]
    public NLog.Layouts.Layout<int> EventId { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the layout used to format log messages.")]
    public NLog.Layouts.Layout Layout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the Event Log to write to. This can be System, Application or any user-defined name.")]
    public NLog.Layouts.Layout Log { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the machine on which Event Log service is running.")]
    public NLog.Layouts.Layout MachineName { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum Event log size in kilobytes.")]
    public NLog.Layouts.Layout<long> MaxKilobytes { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the message length limit to write to the Event Log.")]
    public NLog.Layouts.Layout<int> MaxMessageLength { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the target.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the action to take if the message is larger than the P:NLog.Targets.EventLogTarget.MaxMessageLength option.")]
    public NLog.Targets.EventLogTargetOverflowAction OnOverflow { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the value to be used as the event Source.")]
    public NLog.Layouts.Layout Source { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.EventLogTarget();

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
        {
            instance.Category = Category;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(EntryType)))
        {
            instance.EntryType = EntryType;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(EventId)))
        {
            instance.EventId = EventId;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Layout)))
        {
            instance.Layout = Layout;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Log)))
        {
            instance.Log = Log;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(MachineName)))
        {
            instance.MachineName = MachineName;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(MaxKilobytes)))
        {
            instance.MaxKilobytes = MaxKilobytes;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(MaxMessageLength)))
        {
            instance.MaxMessageLength = MaxMessageLength;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
        {
            instance.Name = Name;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(OnOverflow)))
        {
            instance.OnOverflow = OnOverflow;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
        {
            instance.Source = Source;
        }

        WriteObject(instance);
    }
}

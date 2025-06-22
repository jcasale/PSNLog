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
    public NLog.Targets.EventLogTargetOverflowAction? OnOverflow { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the value to be used as the event Source.")]
    public NLog.Layouts.Layout Source { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.EventLogTarget();

        if (this.Category is not null)
        {
            instance.Category = this.Category;
        }

        if (this.EntryType is not null)
        {
            instance.EntryType = this.EntryType;
        }

        if (this.EventId is not null)
        {
            instance.EventId = this.EventId;
        }

        if (this.Layout is not null)
        {
            instance.Layout = this.Layout;
        }

        if (this.Log is not null)
        {
            instance.Log = this.Log;
        }

        if (this.MachineName is not null)
        {
            instance.MachineName = this.MachineName;
        }

        if (this.MaxKilobytes is not null)
        {
            instance.MaxKilobytes = this.MaxKilobytes;
        }

        if (this.MaxMessageLength is not null)
        {
            instance.MaxMessageLength = this.MaxMessageLength;
        }

        if (this.Name is not null)
        {
            instance.Name = this.Name;
        }

        if (this.OnOverflow.HasValue)
        {
            instance.OnOverflow = this.OnOverflow.Value;
        }

        if (this.Source is not null)
        {
            instance.Source = this.Source;
        }

        this.WriteObject(instance);
    }
}

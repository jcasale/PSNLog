namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogBufferingTargetWrapper")]
[OutputType(typeof(NLog.Targets.Wrappers.BufferingTargetWrapper))]
public class NewBufferingTargetWrapperCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the number of log events to be buffered.")]
    public NLog.Layouts.Layout<int> BufferSize { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the timeout (in milliseconds) after which the contents of buffer will be flushed if there's no write in the specified period of time. Use -1 to disable timed flushes.")]
    public NLog.Layouts.Layout<int> FlushTimeout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the target.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the action to take if the buffer overflows.")]
    public NLog.Targets.Wrappers.BufferingTargetWrapperOverflowAction? OverflowAction { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to use sliding timeout.")]
    public bool? SlidingTimeout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the target that is wrapped by this target.")]
    public NLog.Targets.Target WrappedTarget { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.Wrappers.BufferingTargetWrapper();

        if (BufferSize is not null)
        {
            instance.BufferSize = BufferSize;
        }

        if (FlushTimeout is not null)
        {
            instance.FlushTimeout = FlushTimeout;
        }

        if (Name is not null)
        {
            instance.Name = Name;
        }

        if (OverflowAction.HasValue)
        {
            instance.OverflowAction = OverflowAction.Value;
        }

        if (SlidingTimeout.HasValue)
        {
            instance.SlidingTimeout = SlidingTimeout.Value;
        }

        if (WrappedTarget is not null)
        {
            instance.WrappedTarget = WrappedTarget;
        }

        WriteObject(instance);
    }
}

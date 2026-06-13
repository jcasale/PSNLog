namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogAsyncTargetWrapper")]
[OutputType(typeof(NLog.Targets.Wrappers.AsyncTargetWrapper))]
public class NewAsyncTargetWrapperCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the number of log events that should be processed in a batch by the lazy writer thread.")]
    public int BatchSize { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets whether to use the locking queue, instead of a lock-free concurrent queue.")]
    public bool ForceLockingQueue { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the number of batches of P:NLog.Targets.Wrappers.AsyncTargetWrapper.BatchSize to write before yielding into P:NLog.Targets.Wrappers.AsyncTargetWrapper.TimeToSleepBetweenBatches.")]
    public int FullBatchSizeWriteLimit { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the target.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the action to be taken when the lazy writer thread request queue count exceeds the set limit.")]
    public NLog.Targets.Wrappers.AsyncTargetWrapperOverflowAction OverflowAction { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the limit on the number of requests in the lazy writer thread request queue.")]
    public int QueueLimit { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the time in milliseconds to sleep between batches. (1 or less means trigger on new activity).")]
    public int TimeToSleepBetweenBatches { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the target that is wrapped by this target.")]
    public NLog.Targets.Target WrappedTarget { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.Wrappers.AsyncTargetWrapper();

        if (MyInvocation.BoundParameters.ContainsKey(nameof(BatchSize)))
        {
            instance.BatchSize = BatchSize;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(ForceLockingQueue)))
        {
            instance.ForceLockingQueue = ForceLockingQueue;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(FullBatchSizeWriteLimit)))
        {
            instance.FullBatchSizeWriteLimit = FullBatchSizeWriteLimit;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
        {
            instance.Name = Name;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(OverflowAction)))
        {
            instance.OverflowAction = OverflowAction;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(QueueLimit)))
        {
            instance.QueueLimit = QueueLimit;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeToSleepBetweenBatches)))
        {
            instance.TimeToSleepBetweenBatches = TimeToSleepBetweenBatches;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(WrappedTarget)))
        {
            instance.WrappedTarget = WrappedTarget;
        }

        WriteObject(instance);
    }
}

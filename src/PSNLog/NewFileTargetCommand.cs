namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogFileTarget")]
[OutputType(typeof(NLog.Targets.FileTarget))]
public class NewFileTargetCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the size in bytes above which log files will be automatically archived. Zero or negative means disabled.")]
    public long ArchiveAboveSize { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to trigger archive operation based on time-period, by moving active-file to file-path specified by P:NLog.Targets.FileTarget.ArchiveFileName.")]
    public NLog.Targets.FileArchivePeriod ArchiveEvery { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Legacy archive logic where file-archive-logic moves active file to path specified by P:NLog.Targets.FileTarget.ArchiveFileName, and then recreates the active file. Use P:NLog.Targets.FileTarget.ArchiveSuffixFormat to control suffix format, instead of now obsolete token {#}.")]
    public NLog.Layouts.Layout ArchiveFileName { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether any existing log-file should be archived on startup.")]
    public bool ArchiveOldFileOnStartup { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the format-string to convert archive sequence-number by using string.Format.")]
    public string ArchiveSuffixFormat { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to automatically flush the file buffers after each log message.")]
    public bool AutoFlush { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the log file buffer size in bytes.")]
    public int BufferSize { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to create directories if they do not exist.")]
    public bool CreateDirs { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to delete old log file on startup.")]
    public bool DeleteOldFileOnStartup { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets whether or not this target should just discard all data that its asked to write. Mostly used for when testing NLog Stack except final write.")]
    public bool DiscardAll { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to enable log file(s) to be deleted.")]
    public bool EnableFileDelete { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the file encoding.")]
    public System.Text.Encoding Encoding { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the file to write to.")]
    public NLog.Layouts.Layout FileName { get; set; }

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
        HelpMessage = "Gets or sets a value indicating whether to keep log file open instead of opening and closing it on each logging event.")]
    public bool KeepFileOpen { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the layout used to format log messages.")]
    public NLog.Layouts.Layout Layout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the line ending mode.")]
    public NLog.Targets.LineEndingMode LineEnding { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum days of archive files that should be kept. Zero or negative means disabled.")]
    public int MaxArchiveDays { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum number of archive files that should be kept. Negative means disabled.")]
    public int MaxArchiveFiles { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the target.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum number of files to be kept open.")]
    public int OpenFileCacheSize { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum number of seconds that files are kept open. Zero or negative means disabled.")]
    public int OpenFileCacheTimeout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum number of seconds before open files are flushed. Zero or negative means disabled.")]
    public int OpenFileFlushTimeout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to replace file contents on each write instead of appending log message at the end.")]
    public bool ReplaceFileContentsOnEachWrite { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to write BOM (byte order mark) in created files.")]
    public bool WriteBom { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether the footer should be written only when the file is archived.")]
    public bool WriteFooterOnArchivingOnly { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets whether to write the Header on initial creation of file appender, even if the file is not empty. Default value is false, which means only write header when initial file is empty (Ex. ensures valid CSV files).")]
    public bool WriteHeaderWhenInitialFileNotEmpty { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.FileTarget();

        if (MyInvocation.BoundParameters.ContainsKey(nameof(ArchiveAboveSize)))
        {
            instance.ArchiveAboveSize = ArchiveAboveSize;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(ArchiveEvery)))
        {
            instance.ArchiveEvery = ArchiveEvery;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(ArchiveFileName)))
        {
            instance.ArchiveFileName = ArchiveFileName;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(ArchiveOldFileOnStartup)))
        {
            instance.ArchiveOldFileOnStartup = ArchiveOldFileOnStartup;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(ArchiveSuffixFormat)))
        {
            instance.ArchiveSuffixFormat = ArchiveSuffixFormat;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(AutoFlush)))
        {
            instance.AutoFlush = AutoFlush;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(BufferSize)))
        {
            instance.BufferSize = BufferSize;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(CreateDirs)))
        {
            instance.CreateDirs = CreateDirs;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(DeleteOldFileOnStartup)))
        {
            instance.DeleteOldFileOnStartup = DeleteOldFileOnStartup;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(DiscardAll)))
        {
            instance.DiscardAll = DiscardAll;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(EnableFileDelete)))
        {
            instance.EnableFileDelete = EnableFileDelete;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Encoding)))
        {
            instance.Encoding = Encoding;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(FileName)))
        {
            instance.FileName = FileName;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Footer)))
        {
            instance.Footer = Footer;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Header)))
        {
            instance.Header = Header;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(KeepFileOpen)))
        {
            instance.KeepFileOpen = KeepFileOpen;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Layout)))
        {
            instance.Layout = Layout;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(LineEnding)))
        {
            instance.LineEnding = LineEnding;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(MaxArchiveDays)))
        {
            instance.MaxArchiveDays = MaxArchiveDays;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(MaxArchiveFiles)))
        {
            instance.MaxArchiveFiles = MaxArchiveFiles;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
        {
            instance.Name = Name;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(OpenFileCacheSize)))
        {
            instance.OpenFileCacheSize = OpenFileCacheSize;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(OpenFileCacheTimeout)))
        {
            instance.OpenFileCacheTimeout = OpenFileCacheTimeout;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(OpenFileFlushTimeout)))
        {
            instance.OpenFileFlushTimeout = OpenFileFlushTimeout;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(ReplaceFileContentsOnEachWrite)))
        {
            instance.ReplaceFileContentsOnEachWrite = ReplaceFileContentsOnEachWrite;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(WriteBom)))
        {
            instance.WriteBom = WriteBom;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(WriteFooterOnArchivingOnly)))
        {
            instance.WriteFooterOnArchivingOnly = WriteFooterOnArchivingOnly;
        }

        if (MyInvocation.BoundParameters.ContainsKey(nameof(WriteHeaderWhenInitialFileNotEmpty)))
        {
            instance.WriteHeaderWhenInitialFileNotEmpty = WriteHeaderWhenInitialFileNotEmpty;
        }

        WriteObject(instance);
    }
}

namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogFileTarget")]
[OutputType(typeof(NLog.Targets.FileTarget))]
public class NewFileTargetCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the size in bytes above which log files will be automatically archived.")]
    public long? ArchiveAboveSize { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value specifying the date format to use when archiving files.")]
    public string ArchiveDateFormat { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to automatically archive log files every time the specified time passes.")]
    public NLog.Targets.FileArchivePeriod? ArchiveEvery { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Is the P:NLog.Targets.FileTarget.ArchiveFileName an absolute or relative path?")]
    public NLog.Targets.FilePathKind? ArchiveFileKind { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the file to be used for an archive.")]
    public NLog.Layouts.Layout ArchiveFileName { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the way file archives are numbered.")]
    public NLog.Targets.ArchiveNumberingMode? ArchiveNumbering { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to archive old log file on startup.")]
    public bool? ArchiveOldFileOnStartup { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value of the file size threshold to archive old log file on startup.")]
    public long? ArchiveOldFileOnStartupAboveSize { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to automatically flush the file buffers after each log message.")]
    public bool? AutoFlush { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the log file buffer size in bytes.")]
    public int? BufferSize { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Cleanup invalid values in a filename, e.g. slashes in a filename. If set to true, this can impact the performance of massive writes. If set to false, nothing gets written when the filename is wrong.")]
    public bool? CleanupFileName { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the delay in milliseconds to wait before attempting to write to the file again.")]
    public int? ConcurrentWriteAttemptDelay { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the number of times the write is appended on the file before NLog discards the log message.")]
    public int? ConcurrentWriteAttempts { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether concurrent writes to the log file by multiple processes on the same host.")]
    public bool? ConcurrentWrites { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to create directories if they do not exist.")]
    public bool? CreateDirs { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to delete old log file on startup.")]
    public bool? DeleteOldFileOnStartup { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets whether or not this target should just discard all data that its asked to write. Mostly used for when testing NLog Stack except final write.")]
    public bool? DiscardAll { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to compress archive files into the zip archive format.")]
    public bool? EnableArchiveFileCompression { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to enable log file(s) to be deleted.")]
    public bool? EnableFileDelete { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the file encoding.")]
    public System.Text.Encoding Encoding { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the file attributes (Windows only).")]
    public NLog.Targets.Win32FileAttributes? FileAttributes { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the file to write to.")]
    public NLog.Layouts.Layout FileName { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Is the P:NLog.Targets.FileTarget.FileName an absolute or relative path?")]
    public NLog.Targets.FilePathKind? FileNameKind { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the footer.")]
    public NLog.Layouts.Layout Footer { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or set a value indicating whether a managed file stream is forced, instead of using the native implementation.")]
    public bool? ForceManaged { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether file creation calls should be synchronized by a system global mutex.")]
    public bool? ForceMutexConcurrentWrites { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the header.")]
    public NLog.Layouts.Layout Header { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to keep log file open instead of opening and closing it on each logging event.")]
    public bool? KeepFileOpen { get; set; }

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
        HelpMessage = "Gets or sets the maximum days of archive files that should be kept.")]
    public int? MaxArchiveDays { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum number of archive files that should be kept.")]
    public int? MaxArchiveFiles { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the target.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the number of files to be kept open. Setting this to a higher value may improve performance in a situation where a single File target is writing to many files (such as splitting by level or by logger).")]
    public int? OpenFileCacheSize { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum number of seconds that files are kept open. Zero or negative means disabled.")]
    public int? OpenFileCacheTimeout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum number of seconds before open files are flushed. Zero or negative means disabled.")]
    public int? OpenFileFlushTimeout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to replace file contents on each write instead of appending log message at the end.")]
    public bool? ReplaceFileContentsOnEachWrite { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to write BOM (byte order mark) in created files. Defaults to true for UTF-16 and UTF-32.")]
    public bool? WriteBom { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether the footer should be written only when the file is archived.")]
    public bool? WriteFooterOnArchivingOnly { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets whether to write the Header on initial creation of file appender, even if the file is not empty. Default value is , which means only write header when initial file is empty (Ex. ensures valid CSV files).")]
    public bool? WriteHeaderWhenInitialFileNotEmpty { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.FileTarget();

        if (this.ArchiveAboveSize.HasValue)
        {
            instance.ArchiveAboveSize = this.ArchiveAboveSize.Value;
        }

        if (this.ArchiveDateFormat is not null)
        {
            instance.ArchiveDateFormat = this.ArchiveDateFormat;
        }

        if (this.ArchiveEvery.HasValue)
        {
            instance.ArchiveEvery = this.ArchiveEvery.Value;
        }

        if (this.ArchiveFileKind.HasValue)
        {
            instance.ArchiveFileKind = this.ArchiveFileKind.Value;
        }

        if (this.ArchiveFileName is not null)
        {
            instance.ArchiveFileName = this.ArchiveFileName;
        }

        if (this.ArchiveNumbering.HasValue)
        {
            instance.ArchiveNumbering = this.ArchiveNumbering.Value;
        }

        if (this.ArchiveOldFileOnStartup.HasValue)
        {
            instance.ArchiveOldFileOnStartup = this.ArchiveOldFileOnStartup.Value;
        }

        if (this.ArchiveOldFileOnStartupAboveSize.HasValue)
        {
            instance.ArchiveOldFileOnStartupAboveSize = this.ArchiveOldFileOnStartupAboveSize.Value;
        }

        if (this.AutoFlush.HasValue)
        {
            instance.AutoFlush = this.AutoFlush.Value;
        }

        if (this.BufferSize.HasValue)
        {
            instance.BufferSize = this.BufferSize.Value;
        }

        if (this.CleanupFileName.HasValue)
        {
            instance.CleanupFileName = this.CleanupFileName.Value;
        }

        if (this.ConcurrentWriteAttemptDelay.HasValue)
        {
            instance.ConcurrentWriteAttemptDelay = this.ConcurrentWriteAttemptDelay.Value;
        }

        if (this.ConcurrentWriteAttempts.HasValue)
        {
            instance.ConcurrentWriteAttempts = this.ConcurrentWriteAttempts.Value;
        }

        if (this.ConcurrentWrites.HasValue)
        {
            instance.ConcurrentWrites = this.ConcurrentWrites.Value;
        }

        if (this.CreateDirs.HasValue)
        {
            instance.CreateDirs = this.CreateDirs.Value;
        }

        if (this.DeleteOldFileOnStartup.HasValue)
        {
            instance.DeleteOldFileOnStartup = this.DeleteOldFileOnStartup.Value;
        }

        if (this.DiscardAll.HasValue)
        {
            instance.DiscardAll = this.DiscardAll.Value;
        }

        if (this.EnableArchiveFileCompression.HasValue)
        {
            instance.EnableArchiveFileCompression = this.EnableArchiveFileCompression.Value;
        }

        if (this.EnableFileDelete.HasValue)
        {
            instance.EnableFileDelete = this.EnableFileDelete.Value;
        }

        if (this.Encoding is not null)
        {
            instance.Encoding = this.Encoding;
        }

        if (this.FileAttributes.HasValue)
        {
            instance.FileAttributes = this.FileAttributes.Value;
        }

        if (this.FileName is not null)
        {
            instance.FileName = this.FileName;
        }

        if (this.FileNameKind.HasValue)
        {
            instance.FileNameKind = this.FileNameKind.Value;
        }

        if (this.Footer is not null)
        {
            instance.Footer = this.Footer;
        }

        if (this.ForceManaged.HasValue)
        {
            instance.ForceManaged = this.ForceManaged.Value;
        }

        if (this.ForceMutexConcurrentWrites.HasValue)
        {
            instance.ForceMutexConcurrentWrites = this.ForceMutexConcurrentWrites.Value;
        }

        if (this.Header is not null)
        {
            instance.Header = this.Header;
        }

        if (this.KeepFileOpen.HasValue)
        {
            instance.KeepFileOpen = this.KeepFileOpen.Value;
        }

        if (this.Layout is not null)
        {
            instance.Layout = this.Layout;
        }

        if (this.LineEnding is not null)
        {
            instance.LineEnding = this.LineEnding;
        }

        if (this.MaxArchiveDays.HasValue)
        {
            instance.MaxArchiveDays = this.MaxArchiveDays.Value;
        }

        if (this.MaxArchiveFiles.HasValue)
        {
            instance.MaxArchiveFiles = this.MaxArchiveFiles.Value;
        }

        if (this.Name is not null)
        {
            instance.Name = this.Name;
        }

        if (this.OpenFileCacheSize.HasValue)
        {
            instance.OpenFileCacheSize = this.OpenFileCacheSize.Value;
        }

        if (this.OpenFileCacheTimeout.HasValue)
        {
            instance.OpenFileCacheTimeout = this.OpenFileCacheTimeout.Value;
        }

        if (this.OpenFileFlushTimeout.HasValue)
        {
            instance.OpenFileFlushTimeout = this.OpenFileFlushTimeout.Value;
        }

        if (this.ReplaceFileContentsOnEachWrite.HasValue)
        {
            instance.ReplaceFileContentsOnEachWrite = this.ReplaceFileContentsOnEachWrite.Value;
        }

        if (this.WriteBom.HasValue)
        {
            instance.WriteBom = this.WriteBom.Value;
        }

        if (this.WriteFooterOnArchivingOnly.HasValue)
        {
            instance.WriteFooterOnArchivingOnly = this.WriteFooterOnArchivingOnly.Value;
        }

        if (this.WriteHeaderWhenInitialFileNotEmpty.HasValue)
        {
            instance.WriteHeaderWhenInitialFileNotEmpty = this.WriteHeaderWhenInitialFileNotEmpty.Value;
        }

        this.WriteObject(instance);
    }
}

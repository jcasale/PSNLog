namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogFileTarget")]
[OutputType(typeof(NLog.Targets.FileTarget))]
public class NewFileTargetCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the size in bytes above which log files will be automatically archived. Zero or negative means disabled.")]
    public long? ArchiveAboveSize { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to trigger archive operation based on time-period, by moving active-file to file-path specified by P:NLog.Targets.FileTarget.ArchiveFileName.")]
    public NLog.Targets.FileArchivePeriod? ArchiveEvery { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Legacy archive logic where file-archive-logic moves active file to path specified by P:NLog.Targets.FileTarget.ArchiveFileName, and then recreates the active file. Use P:NLog.Targets.FileTarget.ArchiveSuffixFormat to control suffix format, instead of now obsolete token {#}.")]
    public NLog.Layouts.Layout ArchiveFileName { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether any existing log-file should be archived on startup.")]
    public bool? ArchiveOldFileOnStartup { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the format-string to convert archive sequence-number by using string.Format.")]
    public string ArchiveSuffixFormat { get; set; }

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
        HelpMessage = "Gets or sets a value indicating whether to enable log file(s) to be deleted.")]
    public bool? EnableFileDelete { get; set; }

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
        HelpMessage = "Gets or sets the maximum days of archive files that should be kept. Zero or negative means disabled.")]
    public int? MaxArchiveDays { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum number of archive files that should be kept. Negative means disabled.")]
    public int? MaxArchiveFiles { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the target.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the maximum number of files to be kept open.")]
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
        HelpMessage = "Gets or sets a value indicating whether to write BOM (byte order mark) in created files.")]
    public bool? WriteBom { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether the footer should be written only when the file is archived.")]
    public bool? WriteFooterOnArchivingOnly { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets whether to write the Header on initial creation of file appender, even if the file is not empty. Default value is false, which means only write header when initial file is empty (Ex. ensures valid CSV files).")]
    public bool? WriteHeaderWhenInitialFileNotEmpty { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.FileTarget();

        if (ArchiveAboveSize.HasValue)
        {
            instance.ArchiveAboveSize = ArchiveAboveSize.Value;
        }

        if (ArchiveEvery.HasValue)
        {
            instance.ArchiveEvery = ArchiveEvery.Value;
        }

        if (ArchiveFileName is not null)
        {
            instance.ArchiveFileName = ArchiveFileName;
        }

        if (ArchiveOldFileOnStartup.HasValue)
        {
            instance.ArchiveOldFileOnStartup = ArchiveOldFileOnStartup.Value;
        }

        if (ArchiveSuffixFormat is not null)
        {
            instance.ArchiveSuffixFormat = ArchiveSuffixFormat;
        }

        if (AutoFlush.HasValue)
        {
            instance.AutoFlush = AutoFlush.Value;
        }

        if (BufferSize.HasValue)
        {
            instance.BufferSize = BufferSize.Value;
        }

        if (CreateDirs.HasValue)
        {
            instance.CreateDirs = CreateDirs.Value;
        }

        if (DeleteOldFileOnStartup.HasValue)
        {
            instance.DeleteOldFileOnStartup = DeleteOldFileOnStartup.Value;
        }

        if (DiscardAll.HasValue)
        {
            instance.DiscardAll = DiscardAll.Value;
        }

        if (EnableFileDelete.HasValue)
        {
            instance.EnableFileDelete = EnableFileDelete.Value;
        }

        if (Encoding is not null)
        {
            instance.Encoding = Encoding;
        }

        if (FileName is not null)
        {
            instance.FileName = FileName;
        }

        if (Footer is not null)
        {
            instance.Footer = Footer;
        }

        if (Header is not null)
        {
            instance.Header = Header;
        }

        if (KeepFileOpen.HasValue)
        {
            instance.KeepFileOpen = KeepFileOpen.Value;
        }

        if (Layout is not null)
        {
            instance.Layout = Layout;
        }

        if (LineEnding is not null)
        {
            instance.LineEnding = LineEnding;
        }

        if (MaxArchiveDays.HasValue)
        {
            instance.MaxArchiveDays = MaxArchiveDays.Value;
        }

        if (MaxArchiveFiles.HasValue)
        {
            instance.MaxArchiveFiles = MaxArchiveFiles.Value;
        }

        if (Name is not null)
        {
            instance.Name = Name;
        }

        if (OpenFileCacheSize.HasValue)
        {
            instance.OpenFileCacheSize = OpenFileCacheSize.Value;
        }

        if (OpenFileCacheTimeout.HasValue)
        {
            instance.OpenFileCacheTimeout = OpenFileCacheTimeout.Value;
        }

        if (OpenFileFlushTimeout.HasValue)
        {
            instance.OpenFileFlushTimeout = OpenFileFlushTimeout.Value;
        }

        if (ReplaceFileContentsOnEachWrite.HasValue)
        {
            instance.ReplaceFileContentsOnEachWrite = ReplaceFileContentsOnEachWrite.Value;
        }

        if (WriteBom.HasValue)
        {
            instance.WriteBom = WriteBom.Value;
        }

        if (WriteFooterOnArchivingOnly.HasValue)
        {
            instance.WriteFooterOnArchivingOnly = WriteFooterOnArchivingOnly.Value;
        }

        if (WriteHeaderWhenInitialFileNotEmpty.HasValue)
        {
            instance.WriteHeaderWhenInitialFileNotEmpty = WriteHeaderWhenInitialFileNotEmpty.Value;
        }

        WriteObject(instance);
    }
}

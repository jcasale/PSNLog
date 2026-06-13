---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 06-13-2026
PlatyPS schema version: 2024-05-01
title: New-NLogFileTarget
---

# New-NLogFileTarget

## SYNOPSIS

Creates a file target.

## SYNTAX

### __AllParameterSets

```
New-NLogFileTarget [-ArchiveAboveSize <long>] [-ArchiveEvery <FileArchivePeriod>]
 [-ArchiveFileName <Layout>] [-ArchiveOldFileOnStartup <bool>] [-ArchiveSuffixFormat <string>]
 [-AutoFlush <bool>] [-BufferSize <int>] [-CreateDirs <bool>] [-DeleteOldFileOnStartup <bool>]
 [-DiscardAll <bool>] [-EnableFileDelete <bool>] [-Encoding <Encoding>] [-FileName <Layout>]
 [-Footer <Layout>] [-Header <Layout>] [-KeepFileOpen <bool>] [-Layout <Layout>]
 [-LineEnding <LineEndingMode>] [-MaxArchiveDays <int>] [-MaxArchiveFiles <int>] [-Name <string>]
 [-OpenFileCacheSize <int>] [-OpenFileCacheTimeout <int>] [-OpenFileFlushTimeout <int>]
 [-ReplaceFileContentsOnEachWrite <bool>] [-WriteBom <bool>] [-WriteFooterOnArchivingOnly <bool>]
 [-WriteHeaderWhenInitialFileNotEmpty <bool>] [<CommonParameters>]
```

## ALIASES

None.


## DESCRIPTION

The New-NLogFileTarget cmdlet creates a file target.

## EXAMPLES

### Example 1: Create a file target

```powershell
$configuration = New-NLogLoggingConfiguration
$target = New-NLogFileTarget -FileName 'x:\path\logfile.log' -Name FileTarget
$rule = New-NLogLoggingRule `
  -Target $target `
  -Name FileRule `
  -LoggerNamePattern * `
  -MinLevel Trace `
  -MaxLevel Fatal
Add-NLogLoggingRule -Configuration $configuration -Rule $rule
Add-NLogLoggingConfiguration $configuration
$logger = Get-NLogLogger -Name MyLogger
```

This example creates a logger with a file target.

## PARAMETERS

### -ArchiveAboveSize

Gets or sets the size in bytes above which log files will be automatically archived. Zero or negative means disabled.

```yaml
Type: System.Int64
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ArchiveEvery

Gets or sets a value indicating whether to trigger archive operation based on time-period, by moving active-file to file-path specified by P:NLog.Targets.FileTarget.ArchiveFileName.

```yaml
Type: NLog.Targets.FileArchivePeriod
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ArchiveFileName

Legacy archive logic where file-archive-logic moves active file to path specified by P:NLog.Targets.FileTarget.ArchiveFileName, and then recreates the active file. Use P:NLog.Targets.FileTarget.ArchiveSuffixFormat to control suffix format, instead of now obsolete token {#}.

```yaml
Type: NLog.Layouts.Layout
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ArchiveOldFileOnStartup

Gets or sets a value indicating whether any existing log-file should be archived on startup.

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ArchiveSuffixFormat

Gets or sets the format-string to convert archive sequence-number by using string.Format.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -AutoFlush

Gets or sets a value indicating whether to automatically flush the file buffers after each log message.

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -BufferSize

Gets or sets the log file buffer size in bytes.

```yaml
Type: System.Int32
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -CreateDirs

Gets or sets a value indicating whether to create directories if they do not exist.

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -DeleteOldFileOnStartup

Gets or sets a value indicating whether to delete old log file on startup.

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -DiscardAll

Gets or sets whether or not this target should just discard all data that its asked to write. Mostly used for when testing NLog Stack except final write.

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -EnableFileDelete

Gets or sets a value indicating whether to enable log file(s) to be deleted.

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Encoding

Gets or sets the file encoding.

```yaml
Type: System.Text.Encoding
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -FileName

Gets or sets the name of the file to write to.

```yaml
Type: NLog.Layouts.Layout
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Footer

Gets or sets the footer.

```yaml
Type: NLog.Layouts.Layout
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Header

Gets or sets the header.

```yaml
Type: NLog.Layouts.Layout
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -KeepFileOpen

Gets or sets a value indicating whether to keep log file open instead of opening and closing it on each logging event.

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Layout

Gets or sets the layout used to format log messages.

```yaml
Type: NLog.Layouts.Layout
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -LineEnding

Gets or sets the line ending mode.

```yaml
Type: NLog.Targets.LineEndingMode
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -MaxArchiveDays

Gets or sets the maximum days of archive files that should be kept. Zero or negative means disabled.

```yaml
Type: System.Int32
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -MaxArchiveFiles

Gets or sets the maximum number of archive files that should be kept. Negative means disabled.

```yaml
Type: System.Int32
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

Gets or sets the name of the target.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -OpenFileCacheSize

Gets or sets the maximum number of files to be kept open.

```yaml
Type: System.Int32
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -OpenFileCacheTimeout

Gets or sets the maximum number of seconds that files are kept open. Zero or negative means disabled.

```yaml
Type: System.Int32
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -OpenFileFlushTimeout

Gets or sets the maximum number of seconds before open files are flushed. Zero or negative means disabled.

```yaml
Type: System.Int32
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ReplaceFileContentsOnEachWrite

Gets or sets a value indicating whether to replace file contents on each write instead of appending log message at the end.

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WriteBom

Gets or sets a value indicating whether to write BOM (byte order mark) in created files.

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WriteFooterOnArchivingOnly

Gets or sets a value indicating whether the footer should be written only when the file is archived.

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WriteHeaderWhenInitialFileNotEmpty

Gets or sets whether to write the Header on initial creation of file appender, even if the file is not empty. Default value is false, which means only write header when initial file is empty (Ex. ensures valid CSV files).

```yaml
Type: System.Boolean
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Int64

You can pipe objects with an ArchiveAboveSize property that specifies the size in bytes above which log files are archived.

### NLog.Targets.FileArchivePeriod

You can pipe objects with an ArchiveEvery property that specifies the archive period for moving the active file.

### NLog.Layouts.Layout

You can pipe objects with an ArchiveFileName property that specifies the archive file name layout.

### System.Boolean

You can pipe objects with an ArchiveOldFileOnStartup property that indicates whether existing log files are archived on startup.

### System.String

You can pipe objects with an ArchiveSuffixFormat property that specifies the format string for archive sequence numbers.

### System.Boolean

You can pipe objects with an AutoFlush property that indicates whether file buffers are flushed after each log message.

### System.Int32

You can pipe objects with a BufferSize property that specifies the log file buffer size in bytes.

### System.Boolean

You can pipe objects with a CreateDirs property that indicates whether missing directories are created.

### System.Boolean

You can pipe objects with a DeleteOldFileOnStartup property that indicates whether old log files are deleted on startup.

### System.Boolean

You can pipe objects with a DiscardAll property that indicates whether the target discards all data it is asked to write.

### System.Boolean

You can pipe objects with an EnableFileDelete property that indicates whether log files can be deleted.

### System.Text.Encoding

You can pipe objects with an Encoding property that specifies the file encoding.

### NLog.Layouts.Layout

You can pipe objects with a FileName property that specifies the file name layout to write to.

### NLog.Layouts.Layout

You can pipe objects with a Footer property that specifies the footer layout.

### NLog.Layouts.Layout

You can pipe objects with a Header property that specifies the header layout.

### System.Boolean

You can pipe objects with a KeepFileOpen property that indicates whether the log file stays open between logging events.

### NLog.Layouts.Layout

You can pipe objects with a Layout property that specifies the log message layout.

### NLog.Targets.LineEndingMode

You can pipe objects with a LineEnding property that specifies the line ending mode.

### System.Int32

You can pipe objects with a MaxArchiveDays property that specifies how many days of archive files to keep.

### System.Int32

You can pipe objects with a MaxArchiveFiles property that specifies how many archive files to keep.

### System.String

You can pipe objects with a Name property that specifies the target name.

### System.Int32

You can pipe objects with an OpenFileCacheSize property that specifies how many files to keep open.

### System.Int32

You can pipe objects with an OpenFileCacheTimeout property that specifies how many seconds files are kept open.

### System.Int32

You can pipe objects with an OpenFileFlushTimeout property that specifies how many seconds pass before open files are flushed.

### System.Boolean

You can pipe objects with a ReplaceFileContentsOnEachWrite property that indicates whether each write replaces the file contents.

### System.Boolean

You can pipe objects with a WriteBom property that indicates whether to write a byte order mark in created files.

### System.Boolean

You can pipe objects with a WriteFooterOnArchivingOnly property that indicates whether the footer is written only when the file is archived.

### System.Boolean

You can pipe objects with a WriteHeaderWhenInitialFileNotEmpty property that indicates whether the header is written when the initial file is not empty.

## OUTPUTS

### NLog.Targets.FileTarget

Returns a new file target.

## NOTES

## RELATED LINKS

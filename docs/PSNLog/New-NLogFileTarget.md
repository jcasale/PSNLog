---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
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
Type: System.Nullable`1[System.Int64]
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
Type: System.Nullable`1[NLog.Targets.FileArchivePeriod]
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
Type: System.Nullable`1[System.Boolean]
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
Type: System.Nullable`1[System.Boolean]
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
Type: System.Nullable`1[System.Int32]
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
Type: System.Nullable`1[System.Boolean]
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
Type: System.Nullable`1[System.Boolean]
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
Type: System.Nullable`1[System.Boolean]
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
Type: System.Nullable`1[System.Boolean]
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
Type: System.Nullable`1[System.Boolean]
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
Type: System.Nullable`1[System.Int32]
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
Type: System.Nullable`1[System.Int32]
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
Type: System.Nullable`1[System.Int32]
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
Type: System.Nullable`1[System.Int32]
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
Type: System.Nullable`1[System.Int32]
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
Type: System.Nullable`1[System.Boolean]
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
Type: System.Nullable`1[System.Boolean]
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
Type: System.Nullable`1[System.Boolean]
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
Type: System.Nullable`1[System.Boolean]
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

You can pipe an **Int64** value to this cmdlet.

### NLog.Targets.FileArchivePeriod

You can pipe a **FileArchivePeriod** value to this cmdlet.

### NLog.Layouts.Layout

You can pipe an **NLog.Layouts.Layout** object to this cmdlet.

### System.Boolean

You can pipe a Boolean value to this cmdlet.

### System.String

You can pipe a string to this cmdlet.

### System.Int32

You can pipe an **Int32** value to this cmdlet.

### System.Text.Encoding

You can pipe a **System.Text.Encoding** object to this cmdlet.

### NLog.Targets.LineEndingMode

You can pipe a **LineEndingMode** value to this cmdlet.

## OUTPUTS

### NLog.Targets.FileTarget

This cmdlet returns an **NLog.Targets.FileTarget** object.

## NOTES

## RELATED LINKS

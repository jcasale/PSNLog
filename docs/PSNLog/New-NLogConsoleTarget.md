---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 06-13-2026
PlatyPS schema version: 2024-05-01
title: New-NLogConsoleTarget
---

# New-NLogConsoleTarget

## SYNOPSIS

Creates a console target.

## SYNTAX

### __AllParameterSets

```
New-NLogConsoleTarget [-AutoFlush <bool>] [-DetectConsoleAvailable <bool>] [-Encoding <Encoding>]
 [-Footer <Layout>] [-ForceWriteLine <bool>] [-Header <Layout>] [-Layout <Layout>] [-Name <string>]
 [-StdErr <Layout`1[bool]>] [<CommonParameters>]
```

## ALIASES

None.


## DESCRIPTION

The New-NLogConsoleTarget cmdlet creates a console target.

## EXAMPLES

### Example 1: Create a console target

```powershell
$configuration = New-NLogLoggingConfiguration
$target = New-NLogConsoleTarget -Name ConsoleTarget
$rule = New-NLogLoggingRule `
  -Target $target `
  -Name ConsoleRule `
  -LoggerNamePattern * `
  -MinLevel Trace `
  -MaxLevel Fatal
Add-NLogLoggingRule -Configuration $configuration -Rule $rule
Add-NLogLoggingConfiguration $configuration
$logger = Get-NLogLogger -Name MyLogger
```

This example creates a logger with a console target.

## PARAMETERS

### -AutoFlush

Gets or sets a value indicating whether to auto-flush after M:System.Console.WriteLine.

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

### -DetectConsoleAvailable

Gets or sets a value indicating whether to auto-check if the console is available - Disables console writing if Environment.UserInteractive = false (Windows Service) - Disables console writing if Console Standard Input is not available (Non-Console-App).

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

The encoding for writing messages to the T:System.Console.

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

### -ForceWriteLine

Gets or sets whether to force M:System.Console.WriteLine (slower) instead of the faster internal buffering.

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

### -StdErr

Gets or sets a value indicating whether to send the log messages to the standard error instead of the standard output.

```yaml
Type: NLog.Layouts.Layout`1[System.Boolean]
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

### System.Boolean

You can pipe objects with an AutoFlush property that indicates whether to flush after each console write.

### System.Boolean

You can pipe objects with a DetectConsoleAvailable property that indicates whether console availability should be checked automatically.

### System.Text.Encoding

You can pipe objects with an Encoding property that specifies the encoding used to write console messages.

### NLog.Layouts.Layout

You can pipe objects with a Footer property that specifies the footer layout.

### System.Boolean

You can pipe objects with a ForceWriteLine property that indicates whether to force console writes instead of using internal buffering.

### NLog.Layouts.Layout

You can pipe objects with a Header property that specifies the header layout.

### NLog.Layouts.Layout

You can pipe objects with a Layout property that specifies the log message layout.

### System.String

You can pipe objects with a Name property that specifies the target name.

### NLog.Layouts.Layout`1[System.Boolean]

You can pipe objects with a StdErr property that indicates whether log messages are sent to standard error instead of standard output.

## OUTPUTS

### NLog.Targets.ConsoleTarget

Returns a new console target.

## NOTES

## RELATED LINKS

---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 06-13-2026
PlatyPS schema version: 2024-05-01
title: New-NLogColoredConsoleTarget
---

# New-NLogColoredConsoleTarget

## SYNOPSIS

Creates a colored console target.

## SYNTAX

### __AllParameterSets

```
New-NLogColoredConsoleTarget [-AutoFlush <bool>] [-DetectConsoleAvailable <bool>]
 [-DetectOutputRedirected <bool>] [-EnableAnsiOutput <bool>] [-Encoding <Encoding>]
 [-Footer <Layout>] [-Header <Layout>] [-Layout <Layout>] [-Name <string>]
 [-NoColor <Layout`1[bool]>] [-RowHighlightingRules <ConsoleRowHighlightingRule[]>]
 [-StdErr <Layout`1[bool]>] [-UseDefaultRowHighlightingRules <bool>]
 [-WordHighlightingRules <ConsoleWordHighlightingRule[]>] [<CommonParameters>]
```

## ALIASES

None.


## DESCRIPTION

The New-NLogColoredConsoleTarget cmdlet creates a colored console target.

## EXAMPLES

### Example 1: Create a colored console target

```powershell
$configuration = New-NLogLoggingConfiguration
$target = New-NLogColoredConsoleTarget -Name ConsoleTarget
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

This example creates a logger with a colored console target.

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

Gets or sets a value indicating whether to auto-check if the console is available. - Disables console writing if Environment.UserInteractive = false (Windows Service) - Disables console writing if Console Standard Input is not available (Non-Console-App).

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

### -DetectOutputRedirected

Gets or sets a value indicating whether to auto-check if the console has been redirected to file - Disables coloring logic when System.Console.IsOutputRedirected = true.

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

### -EnableAnsiOutput

Enables output using ANSI Color Codes.

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

### -NoColor

Support NO_COLOR=1 environment variable. See also https://no-color.org/.

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

### -RowHighlightingRules

Gets the row highlighting rules.

```yaml
Type: NLog.Targets.ConsoleRowHighlightingRule[]
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

### -UseDefaultRowHighlightingRules

Gets or sets a value indicating whether to use default row highlighting rules.

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

### -WordHighlightingRules

Gets the word highlighting rules.

```yaml
Type: NLog.Targets.ConsoleWordHighlightingRule[]
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

### System.Boolean

You can pipe objects with a DetectOutputRedirected property that indicates whether output redirection should be checked automatically.

### System.Boolean

You can pipe objects with an EnableAnsiOutput property that enables ANSI color code output.

### System.Text.Encoding

You can pipe objects with an Encoding property that specifies the encoding used to write console messages.

### NLog.Layouts.Layout

You can pipe objects with a Footer property that specifies the footer layout.

### NLog.Layouts.Layout

You can pipe objects with a Header property that specifies the header layout.

### NLog.Layouts.Layout

You can pipe objects with a Layout property that specifies the log message layout.

### System.String

You can pipe objects with a Name property that specifies the target name.

### NLog.Layouts.Layout`1[System.Boolean]

You can pipe objects with a NoColor property that specifies support for the NO_COLOR environment variable.

### NLog.Targets.ConsoleRowHighlightingRule[]

You can pipe objects with a RowHighlightingRules property that specifies the row highlighting rules.

### NLog.Layouts.Layout`1[System.Boolean]

You can pipe objects with a StdErr property that indicates whether log messages are sent to standard error instead of standard output.

### System.Boolean

You can pipe objects with a UseDefaultRowHighlightingRules property that indicates whether default row highlighting rules are used.

### NLog.Targets.ConsoleWordHighlightingRule[]

You can pipe objects with a WordHighlightingRules property that specifies the word highlighting rules.

## OUTPUTS

### NLog.Targets.ColoredConsoleTarget

Returns a new colored console target.

## NOTES

## RELATED LINKS

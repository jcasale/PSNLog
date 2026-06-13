---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 06-13-2026
PlatyPS schema version: 2024-05-01
title: New-NLogConsoleWordHighlightingRule
---

# New-NLogConsoleWordHighlightingRule

## SYNOPSIS

Creates a colored console word highlighting rule.

## SYNTAX

### __AllParameterSets

```
New-NLogConsoleWordHighlightingRule [-BackgroundColor <ConsoleOutputColor>]
 [-Condition <ConditionExpression>] [-ForegroundColor <ConsoleOutputColor>] [-IgnoreCase <bool>]
 [-Text <string>] [-WholeWords <bool>] [-Words <string[]>] [<CommonParameters>]
```

## ALIASES

None.


## DESCRIPTION

The New-NLogConsoleWordHighlightingRule cmdlet creates a colored console word highlighting rule.

## EXAMPLES

### Example 1: Create a word highlighting rule

```powershell
$rule = New-NLogConsoleWordHighlightingRule `
  -Text 'error' `
  -IgnoreCase $true `
  -ForegroundColor Red
$target = New-NLogColoredConsoleTarget -Name ConsoleTarget -WordHighlightingRules $rule
```

This example creates a word highlighting rule that displays the word "error" in red regardless of case, then applies it to a colored console target.

## PARAMETERS

### -BackgroundColor

Gets or sets the background color.

```yaml
Type: NLog.Targets.ConsoleOutputColor
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

### -Condition

Gets or sets the condition that must be met before scanning the row for highlight of words.

```yaml
Type: NLog.Conditions.ConditionExpression
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

### -ForegroundColor

Gets or sets the foreground color.

```yaml
Type: NLog.Targets.ConsoleOutputColor
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

### -IgnoreCase

Gets or sets a value indicating whether to ignore case when comparing texts.

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

### -Text

Gets or sets the text to be matched for Highlighting.

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

### -WholeWords

Gets or sets a value indicating whether to match whole words only.

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

### -Words

Gets or sets the list of words to be matched for Highlighting.

```yaml
Type: System.String[]
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

### NLog.Targets.ConsoleOutputColor

You can pipe objects with a BackgroundColor property that specifies the background color.

### NLog.Conditions.ConditionExpression

You can pipe objects with a Condition property that specifies the condition required before scanning for highlighted words.

### NLog.Targets.ConsoleOutputColor

You can pipe objects with a ForegroundColor property that specifies the foreground color.

### System.Boolean

You can pipe objects with an IgnoreCase property that indicates whether text comparisons ignore case.

### System.String

You can pipe objects with a Text property that specifies the text to match for highlighting.

### System.Boolean

You can pipe objects with a WholeWords property that indicates whether only whole words are matched.

### System.String[]

You can pipe objects with a Words property that specifies the list of words to match for highlighting.

## OUTPUTS

### NLog.Targets.ConsoleWordHighlightingRule

Returns a new console word highlighting rule.

## NOTES

## RELATED LINKS

---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
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
Type: System.Nullable`1[NLog.Targets.ConsoleOutputColor]
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
Type: System.Nullable`1[NLog.Targets.ConsoleOutputColor]
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

You can pipe a **ConsoleOutputColor** value to this cmdlet.

### NLog.Conditions.ConditionExpression

You can pipe an **NLog.Conditions.ConditionExpression** object to this cmdlet.

### System.Boolean

You can pipe a Boolean value to this cmdlet.

### System.String

You can pipe a string to this cmdlet.

### System.String[]

You can pipe an array of strings to this cmdlet.

## OUTPUTS

### NLog.Targets.ConsoleWordHighlightingRule

This cmdlet returns an **NLog.Targets.ConsoleWordHighlightingRule** object.

## NOTES

## RELATED LINKS

---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: New-NLogConsoleRowHighlightingRule
---

# New-NLogConsoleRowHighlightingRule

## SYNOPSIS

Creates a colored console row highlighting rule.

## SYNTAX

### __AllParameterSets

```
New-NLogConsoleRowHighlightingRule [-BackgroundColor <ConsoleOutputColor>]
 [-Condition <ConditionExpression>] [-ForegroundColor <ConsoleOutputColor>] [<CommonParameters>]
```

## DESCRIPTION

The New-NLogConsoleRowHighlightingRule cmdlet creates a colored console row highlighting rule.

## EXAMPLES

### Example 1: Create a row highlighting rule for Fatal entries

```powershell
$rule = New-NLogConsoleRowHighlightingRule `
  -Condition 'level == LogLevel.Fatal' `
  -ForegroundColor White `
  -BackgroundColor Red
$target = New-NLogColoredConsoleTarget -Name ConsoleTarget -RowHighlightingRules $rule
```

This example creates a row highlighting rule that displays Fatal log entries with white text on a red background, then applies it to a colored console target.

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

Gets or sets the condition that must be met in order to set the specified foreground and background color.

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

## OUTPUTS

### NLog.Targets.ConsoleRowHighlightingRule

This cmdlet returns an **NLog.Targets.ConsoleRowHighlightingRule** object.

## NOTES

## RELATED LINKS

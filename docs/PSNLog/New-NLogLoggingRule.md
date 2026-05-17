---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: New-NLogLoggingRule
---

# New-NLogLoggingRule

## SYNOPSIS

Creates a logging rule.

## SYNTAX

### default

```
New-NLogLoggingRule [-Target] <Target> [-LoggerNamePattern] <string> [-Name] <string> [-Final]
 [<CommonParameters>]
```

### MinLevel

```
New-NLogLoggingRule [-Target] <Target> [-LoggerNamePattern] <string> [-MinLevel] <LogLevel>
 [-Name] <string> [-Final] [<CommonParameters>]
```

### MaxLevel

```
New-NLogLoggingRule [-Target] <Target> [-LoggerNamePattern] <string> [-MinLevel] <LogLevel>
 [-MaxLevel] <LogLevel> [-Name] <string> [-Final] [<CommonParameters>]
```

## DESCRIPTION

The New-NLogLoggingRule cmdlet creates a logging rule.

## EXAMPLES

### Example 1: Create a logging rule

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
```

This example creates a rule for a console target and adds it to the specified configuration.

## PARAMETERS

### -Final

Specifies whether to quit processing further rules when this one matches.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 5
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -LoggerNamePattern

Specifies the logger name pattern.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: default
  Position: 1
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
- Name: MinLevel
  Position: 1
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
- Name: MaxLevel
  Position: 1
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -MaxLevel

Specifies the maximum log level needed to trigger this rule.

```yaml
Type: NLog.LogLevel
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: MaxLevel
  Position: 3
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -MinLevel

Specifies the minimum log level needed to trigger this rule.

```yaml
Type: NLog.LogLevel
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: MinLevel
  Position: 2
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
- Name: MaxLevel
  Position: 2
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

Specifies the name of the rule.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: default
  Position: 4
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
- Name: MinLevel
  Position: 4
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
- Name: MaxLevel
  Position: 4
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Target

Specifies the target to be written to when the rule matches.

```yaml
Type: NLog.Targets.Target
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: default
  Position: 0
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
- Name: MinLevel
  Position: 0
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
- Name: MaxLevel
  Position: 0
  IsRequired: true
  ValueFromPipeline: true
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

### NLog.Targets.Target

You can pipe an **NLog.Targets.Target** object to this cmdlet.

### System.String

You can pipe a string to this cmdlet.

### NLog.LogLevel

You can pipe an **NLog.LogLevel** object to this cmdlet.

### System.Management.Automation.SwitchParameter

You can pipe a **SwitchParameter** value to this cmdlet.

## OUTPUTS

### NLog.Config.LoggingRule

This cmdlet returns an **NLog.Config.LoggingRule** object.

## NOTES

## RELATED LINKS

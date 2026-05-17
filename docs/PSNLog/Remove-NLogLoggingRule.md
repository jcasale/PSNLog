---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: Remove-NLogLoggingRule
---

# Remove-NLogLoggingRule

## SYNOPSIS

Removes a logging rule.

## SYNTAX

### Rule

```
Remove-NLogLoggingRule [-Rule] <LoggingRule> [-Configuration] <LoggingConfiguration>
 [<CommonParameters>]
```

### Name

```
Remove-NLogLoggingRule [-Name] <string> [-Configuration] <LoggingConfiguration> [<CommonParameters>]
```

## DESCRIPTION

The Remove-NLogLoggingRule cmdlet removes a logging rule from the specified configuration either by name or reference.

## EXAMPLES

### Example 1: Remove a rule by reference

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
Remove-NLogLoggingRule -Configuration $configuration -Rule $rule
```

This example creates a basic configuration with a console target, then removes the rule by reference.

## PARAMETERS

### -Configuration

Specifies the configuration to modify.

```yaml
Type: NLog.Config.LoggingConfiguration
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 1
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

Specifies the name of the rule to remove.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Name
  Position: 0
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Rule

Specifies the rule to remove.

```yaml
Type: NLog.Config.LoggingRule
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Rule
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

### NLog.Config.LoggingRule

You can pipe an **NLog.Config.LoggingRule** object to this cmdlet.

### System.String

You can pipe the rule name to this cmdlet.

### NLog.Config.LoggingConfiguration

You can pipe an **NLog.Config.LoggingConfiguration** object to this cmdlet.

## OUTPUTS

### NLog.Config.LoggingConfiguration

This cmdlet does not generate any output.

## NOTES

## RELATED LINKS

---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: Remove-NLogTarget
---

# Remove-NLogTarget

## SYNOPSIS

Removes a target.

## SYNTAX

### Target

```
Remove-NLogTarget [-Target] <Target> [-Configuration] <LoggingConfiguration> [-PassThru]
 [<CommonParameters>]
```

### Name

```
Remove-NLogTarget [-Name] <string> [-Configuration] <LoggingConfiguration> [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION

The Remove-NLogTarget cmdlet removes a target from the specified configuration either by name or reference.

## EXAMPLES

### Example 1: Remove a target by reference

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
Remove-NLogTarget -Configuration $configuration -Target $target
```

This example creates a basic configuration with a console target, then removes the target by reference.

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

Specifies the name of the target to remove.

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

### -PassThru

Returns the configuration object. By default, this cmdlet does not generate any output.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Target

Specifies the target to remove.

```yaml
Type: NLog.Targets.Target
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Target
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

You can pipe the target name to this cmdlet.

### NLog.Config.LoggingConfiguration

You can pipe an **NLog.Config.LoggingConfiguration** object to this cmdlet.

## OUTPUTS

### NLog.Config.LoggingConfiguration

When you use the **PassThru** parameter, this cmdlet returns the **NLog.Config.LoggingConfiguration** object. Otherwise, this cmdlet does not generate any output.

## NOTES

## RELATED LINKS

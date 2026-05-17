---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: New-NLogLoggingConfiguration
---

# New-NLogLoggingConfiguration

## SYNOPSIS

Creates a logging configuration.

## SYNTAX

### XmlLoggingConfiguration

```
New-NLogLoggingConfiguration [[-Path] <string>] [<CommonParameters>]
```

## DESCRIPTION

The New-NLogLoggingConfiguration cmdlet creates a logging configuration that is either empty or configured by an XML logging configuration.

## EXAMPLES

### Example 1: Create an empty configuration

```powershell
$configuration = New-NLogLoggingConfiguration
```

This example creates an empty configuration.

### Example 2: Create an XML based configuration

```powershell
$configuration = New-NLogLoggingConfiguration -Path 'x:\path\NLog.config'
```

This example creates an XML based configuration.

## PARAMETERS

### -Path

Specifies the path to an XML configuration file.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: XmlLoggingConfiguration
  Position: 0
  IsRequired: false
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

### System.String

You can pipe the path to an XML configuration file to this cmdlet.

## OUTPUTS

### NLog.Config.LoggingConfiguration

This cmdlet returns an **NLog.Config.LoggingConfiguration** object.

## NOTES

## RELATED LINKS

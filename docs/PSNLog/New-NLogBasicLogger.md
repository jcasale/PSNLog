---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: New-NLogBasicLogger
---

# New-NLogBasicLogger

## SYNOPSIS

Creates a basic logger with a common configuration.

## SYNTAX

### __AllParameterSets

```
New-NLogBasicLogger [-Name] <string> [-Path] <string> [<CommonParameters>]
```

## DESCRIPTION

The New-NLogBasicLogger cmdlet creates a basic logger with a common configuration.

This cmdlet performs the following functions:

- Creates a new NLog configuration with a console and file target.
- Assigns the new configuration to the static NLog logging configuration.
- Creates a new NLog logger.
- Returns the logger instance.

## EXAMPLES

### Example 1: Create a basic logger

```powershell
$logger = New-NLogBasicLogger -Name MyLogger -Path x:/path/application.log
```

This command creates a new logger with the MyLogger name and writes log entries to the console and indicated path.

## PARAMETERS

### -Name

The name of the logger.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 0
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Path

The name of the log file.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 1
  IsRequired: true
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

### System.String

You can pipe a string to this cmdlet.

## OUTPUTS

### NLog.Config.LoggingConfiguration

This cmdlet returns an **NLog.Config.LoggingConfiguration** object.

## NOTES

## RELATED LINKS

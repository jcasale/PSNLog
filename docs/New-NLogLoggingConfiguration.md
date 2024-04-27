---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# New-NLogLoggingConfiguration

## SYNOPSIS

Creates a logging configuration.

## DESCRIPTION

The New-NLogLoggingConfiguration cmdlet creates a logging configuration that is either empty or configured by an XML logging configuration.

## EXAMPLES

### Example 1: Create an empty configuration.

```powershell
$configuration = New-NLogLoggingConfiguration
```

This example creates an empty configuration.

### Example 2: Create an XML based configuration.

```powershell
$configuration = New-NLogLoggingConfiguration -Path 'x:\path\NLog.config'
```

This example creates an XML based configuration.
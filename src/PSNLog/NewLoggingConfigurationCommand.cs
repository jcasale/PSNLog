namespace PSNLog;

using System;
using System.Management.Automation;

using NLog.Config;

[Cmdlet(VerbsCommon.New, "NLogLoggingConfiguration")]
[OutputType(typeof(LoggingConfiguration))]
public class NewLoggingConfigurationCommand : PSCmdlet
{
    [Parameter(
        Position = 0,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(XmlLoggingConfiguration),
        HelpMessage = "Specifies the path to an XML configuration file.")]
    [ValidateNotNullOrEmpty]
    public string Path { get; set; }

    protected override void ProcessRecord()
    {
        LoggingConfiguration configuration;

        switch (ParameterSetName)
        {
            case ParameterAttribute.AllParameterSets:

                configuration = new LoggingConfiguration();

                break;

            case nameof(XmlLoggingConfiguration):

                try
                {
                    configuration = new XmlLoggingConfiguration(Path);
                }
                catch (Exception e)
                {
                    ThrowTerminatingError(new(e, nameof(XmlLoggingConfiguration), ErrorCategory.NotSpecified, Path));

                    return;
                }

                break;

            default:

                throw new InvalidOperationException("Unknown parameter set.");
        }

        WriteObject(configuration);
    }
}
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

        switch (this.ParameterSetName)
        {
            case ParameterAttribute.AllParameterSets:

                configuration = new LoggingConfiguration();

                break;

            case nameof(XmlLoggingConfiguration):

                try
                {
                    configuration = new XmlLoggingConfiguration(this.Path);
                }
                catch (Exception e)
                {
                    this.ThrowTerminatingError(new ErrorRecord(
                        e,
                        nameof(XmlLoggingConfiguration),
                        ErrorCategory.NotSpecified,
                        this.Path));

                    return;
                }

                break;

            default:

                throw new InvalidOperationException("Unknown parameter set.");
        }

        this.WriteObject(configuration);
    }
}
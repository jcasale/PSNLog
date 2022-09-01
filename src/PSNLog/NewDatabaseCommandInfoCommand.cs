namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogDatabaseCommandInfo")]
[OutputType(typeof(NLog.Targets.DatabaseCommandInfo))]
public class NewDatabaseCommandInfoCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the type of the command.")]
    public System.Data.CommandType? CommandType { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the connection string to run the command against. If not provided, connection string from the target is used.")]
    public NLog.Layouts.Layout ConnectionString { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to ignore failures.")]
    public bool? IgnoreFailures { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets the collection of parameters. Each parameter contains a mapping between NLog layout and a database named or positional parameter.")]
    public NLog.Targets.DatabaseParameterInfo[] Parameters { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the command text.")]
    public NLog.Layouts.Layout Text { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.DatabaseCommandInfo();

        if (this.CommandType.HasValue)
        {
            instance.CommandType = this.CommandType.Value;
        }

        if (this.ConnectionString is not null)
        {
            instance.ConnectionString = this.ConnectionString;
        }

        if (this.IgnoreFailures.HasValue)
        {
            instance.IgnoreFailures = this.IgnoreFailures.Value;
        }

        if (this.Parameters is {Length: > 0})
        {
            foreach (var item in this.Parameters)
            {
                instance.Parameters.Add(item);
            }
        }

        if (this.Text is not null)
        {
            instance.Text = this.Text;
        }

        this.WriteObject(instance);
    }
}

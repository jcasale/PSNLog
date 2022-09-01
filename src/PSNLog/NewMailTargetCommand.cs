namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogMailTarget")]
[OutputType(typeof(NLog.Targets.MailTarget))]
public class NewMailTargetCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to add new lines between log entries.")]
    public bool? AddNewLines { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets BCC email addresses separated by semicolons (e.g. john@domain.com;jane@domain.com).")]
    public NLog.Layouts.Layout Bcc { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets mail message body (repeated for each log message send in one mail).")]
    public NLog.Layouts.Layout Body { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets CC email addresses separated by semicolons (e.g. john@domain.com;jane@domain.com).")]
    public NLog.Layouts.Layout CC { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Specifies how outgoing email messages will be handled.")]
    public System.Net.Mail.SmtpDeliveryMethod? DeliveryMethod { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether SSL (secure sockets layer) should be used when communicating with SMTP server.")]
    public bool? EnableSsl { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets encoding to be used for sending e-mail.")]
    public System.Text.Encoding Encoding { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the footer.")]
    public NLog.Layouts.Layout Footer { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets sender's email address (e.g. joe@domain.com).")]
    public NLog.Layouts.Layout From { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the header.")]
    public NLog.Layouts.Layout Header { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to send message as HTML instead of plain text.")]
    public bool? Html { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the layout used to format log messages.")]
    public NLog.Layouts.Layout Layout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the target.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the folder where applications save mail messages to be processed by the local SMTP server.")]
    public NLog.Layouts.Layout PickupDirectoryLocation { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the priority used for sending mails.")]
    public NLog.Layouts.Layout<System.Net.Mail.MailPriority> Priority { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether NewLine characters in the body should be replaced with tags.")]
    public bool? ReplaceNewlineWithBrTagInHtml { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets SMTP Authentication mode.")]
    public NLog.Targets.SmtpAuthenticationMode? SmtpAuthentication { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the password used to authenticate against SMTP server (used when SmtpAuthentication is set to 'basic').")]
    public NLog.Layouts.Layout SmtpPassword { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the port number that SMTP Server is listening on.")]
    public NLog.Layouts.Layout<int> SmtpPort { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets SMTP Server to be used for sending.")]
    public NLog.Layouts.Layout SmtpServer { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the username used to connect to SMTP server (used when SmtpAuthentication is set to 'basic').")]
    public NLog.Layouts.Layout SmtpUserName { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the mail subject.")]
    public NLog.Layouts.Layout Subject { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating the SMTP client timeout.")]
    public NLog.Layouts.Layout<int> Timeout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets recipients' email addresses separated by semicolons (e.g. john@domain.com;jane@domain.com).")]
    public NLog.Layouts.Layout To { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether the default Settings from System.Net.MailSettings should be used.")]
    public bool? UseSystemNetMailSettings { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.MailTarget();

        if (this.AddNewLines.HasValue)
        {
            instance.AddNewLines = this.AddNewLines.Value;
        }

        if (this.Bcc is not null)
        {
            instance.Bcc = this.Bcc;
        }

        if (this.Body is not null)
        {
            instance.Body = this.Body;
        }

        if (this.CC is not null)
        {
            instance.CC = this.CC;
        }

        if (this.DeliveryMethod.HasValue)
        {
            instance.DeliveryMethod = this.DeliveryMethod.Value;
        }

        if (this.EnableSsl.HasValue)
        {
            instance.EnableSsl = this.EnableSsl.Value;
        }

        if (this.Encoding is not null)
        {
            instance.Encoding = this.Encoding;
        }

        if (this.Footer is not null)
        {
            instance.Footer = this.Footer;
        }

        if (this.From is not null)
        {
            instance.From = this.From;
        }

        if (this.Header is not null)
        {
            instance.Header = this.Header;
        }

        if (this.Html.HasValue)
        {
            instance.Html = this.Html.Value;
        }

        if (this.Layout is not null)
        {
            instance.Layout = this.Layout;
        }

        if (this.Name is not null)
        {
            instance.Name = this.Name;
        }

        if (this.PickupDirectoryLocation is not null)
        {
            instance.PickupDirectoryLocation = this.PickupDirectoryLocation;
        }

        if (this.Priority is not null)
        {
            instance.Priority = this.Priority;
        }

        if (this.ReplaceNewlineWithBrTagInHtml.HasValue)
        {
            instance.ReplaceNewlineWithBrTagInHtml = this.ReplaceNewlineWithBrTagInHtml.Value;
        }

        if (this.SmtpAuthentication.HasValue)
        {
            instance.SmtpAuthentication = this.SmtpAuthentication.Value;
        }

        if (this.SmtpPassword is not null)
        {
            instance.SmtpPassword = this.SmtpPassword;
        }

        if (this.SmtpPort is not null)
        {
            instance.SmtpPort = this.SmtpPort;
        }

        if (this.SmtpServer is not null)
        {
            instance.SmtpServer = this.SmtpServer;
        }

        if (this.SmtpUserName is not null)
        {
            instance.SmtpUserName = this.SmtpUserName;
        }

        if (this.Subject is not null)
        {
            instance.Subject = this.Subject;
        }

        if (this.Timeout is not null)
        {
            instance.Timeout = this.Timeout;
        }

        if (this.To is not null)
        {
            instance.To = this.To;
        }

        if (this.UseSystemNetMailSettings.HasValue)
        {
            instance.UseSystemNetMailSettings = this.UseSystemNetMailSettings.Value;
        }

        this.WriteObject(instance);
    }
}

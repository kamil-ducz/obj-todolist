using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using ToDoList.Domain.Models;

public interface IEmailService
{
    public void SendEmail(string from, string to, string subject, string body);
    public void SendWelcomeEmail(User user);
}

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public void SendEmail(string to, string subject, string html, string from = null)
    {
        // create message
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(from));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = html };

        // send email
        // due to Google newest security reasons not able anymore to send email like below
        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        smtp.Connect(_smtpSettings.Host, _smtpSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_smtpSettings.Username, _smtpSettings.Password);
        smtp.Send(email);
        smtp.Disconnect(true);
    }

    public void SendWelcomeEmail(User user)
    {
        string from = ""; // Replace with your email address
        string to = user.Email;
        string subject = "Welcome to ToDoListSmarter";
        string body = $"Dear {user.Username},\n\nWelcome to our application! Thank you for registering.";

        SendEmail(to, subject, body, from);
    }
}

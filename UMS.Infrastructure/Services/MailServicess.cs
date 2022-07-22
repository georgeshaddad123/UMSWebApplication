using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using UMS.Domain.Models;
using UMS.Infrastructure.Abstraction.MailServices;

namespace UMS.Infrastructure.Services;

public class MailServicess : IMailServicess
{
    private readonly MailSettings _mailSettings;
    public MailServicess(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    
    public async Task SendEmailAsync(MailRequest mailRequest)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse("paper61kaper@outlook.com");
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;
        var builder = new BodyBuilder();
        
        builder.HtmlBody = mailRequest.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("paper61kaper@outlook.com", "Paper@61");
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }
}
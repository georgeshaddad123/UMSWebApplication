using UMS.Domain.Models;

namespace UMS.Infrastructure.Abstraction.MailServices;

public interface IMailServicess
{
    Task SendEmailAsync(MailRequest mailRequest);
}
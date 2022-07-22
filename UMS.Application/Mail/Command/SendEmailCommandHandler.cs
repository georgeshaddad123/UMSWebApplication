using AutoMapper;
using MailKit;
using MediatR;
using UMS.Domain.Models;
using UMS.Infrastructure;
using UMS.Infrastructure.Abstraction.MailServices;
using UMS.Persistence;

namespace UMS.Application.Mail.Command;

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, bool>
{
    private readonly IMailServicess _mailService;

    public SendEmailCommandHandler(IMailServicess mailService)
    {
        _mailService = mailService;
    }

    public async Task<bool> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var mail = new MailRequest();
            mail.Body = request.Body;
            mail.Subject = request.Subject;
            mail.ToEmail = request.ToEmail;
            await _mailService.SendEmailAsync(mail);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
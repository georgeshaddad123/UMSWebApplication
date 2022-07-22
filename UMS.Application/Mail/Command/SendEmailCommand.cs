using MediatR;

namespace UMS.Application.Mail.Command;

public class SendEmailCommand : IRequest<bool>
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
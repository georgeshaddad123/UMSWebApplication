using MediatR;

namespace UMS.Application.ChatHub.Command;

public class PushNotificationCommand : IRequest<string>
{
    public string AppSectionThatSentTheNotification { get; set; }
    public string Message { get; set; }
}
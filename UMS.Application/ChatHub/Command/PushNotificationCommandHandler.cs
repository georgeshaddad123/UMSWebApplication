using AutoMapper;
using MediatR;
using UMS.Infrastructure.Abstraction.ChatHub;
using UMS.Persistence;

namespace UMS.Application.ChatHub.Command;

public class PushNotificationCommandHandler : IRequestHandler<PushNotificationCommand, string>
{
    private readonly IChatHub _chatHub;

    public PushNotificationCommandHandler(IChatHub chatHub)
    {
        _chatHub = chatHub;
    }
    
    public async Task<string> Handle(PushNotificationCommand request, CancellationToken cancellationToken)
    {
        Task t = _chatHub.SendMessage(request.AppSectionThatSentTheNotification, request.Message);
        return t.ToString();
    }
}
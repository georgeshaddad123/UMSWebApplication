using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.ChatHub.Command;

namespace UMSWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SignalRController : ControllerBase
{
    private readonly IMediator _mediator;

    public SignalRController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("testSignalR")]
    public async Task<IActionResult> TestSignalR(string notification)
    {
        var result = await _mediator.Send(new PushNotificationCommand()
        {
            AppSectionThatSentTheNotification = "Notification :)",
            Message = notification
        });
        return Ok(result);
    }
}
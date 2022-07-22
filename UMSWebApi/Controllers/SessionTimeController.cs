using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.SessionTime.Command.AddSessionTime;
using UMS.Application.Teacher.Command.RegisterCourse;

namespace UMSWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionTimeController : ControllerBase
{
    private readonly IMediator _mediator;

    public SessionTimeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("addSessionTime")]
    public async Task<IActionResult> AddSessionTime(AddSessionTimeCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}
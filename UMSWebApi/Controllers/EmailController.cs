using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.Course.Command.AddCourse;
using UMS.Application.Mail.Command;

namespace UMSWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("generateEmail")]
    public async Task<IActionResult> GenerateEmail([FromForm]SendEmailCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}
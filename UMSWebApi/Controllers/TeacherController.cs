using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.Teacher.Command.RegisterCourse;
using UMS.Application.Teacher.Command.TeacherCourseToSessionTime;

namespace UMSWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("registerCourse")]
    public async Task<IActionResult> RegisterCourse(RegisterCourseCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPost("addToSessionTime")]
    public async Task<IActionResult> AddToSessionTime(AddTeacherToSessionTimeCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}
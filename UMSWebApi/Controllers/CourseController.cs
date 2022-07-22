using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.Course.Command.AddCourse;

namespace UMSWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("addCourse")]
    public async Task<IActionResult> AddUser([FromBody] AddCourseCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}
﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.SessionTime.Command.AddSessionTime;
using UMS.Application.Student.Command.EnrollStudent;
using UMS.Application.Student.Querry.GetStudentsPerCourse;
using UMS.Application.Teacher.Command.RegisterCourse;

namespace UMSWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("enrollClass")]
    public async Task<IActionResult> Enrollement(EnrollStudentCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpGet("{identifier}")]
    public async Task<IActionResult> GetStudentsByCourse([FromRoute] int identifier)
    {
        return Ok(await _mediator.Send(new GetStudentPerCourseQuerry()
        {
            CourseId = identifier
        }));
    }
}
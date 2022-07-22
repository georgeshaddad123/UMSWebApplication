using MailKit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.User.Command.AddUser;
using UMS.Application.User.Command.DeleteUser;
using UMS.Application.User.Command.UpdateUser;
using UMS.Application.User.Querry.GetAllUsers;
using UMS.Application.User.Querry.GetUsersById;
using UMS.Application.User.Querry.GetUsersByName;
using UMS.Domain.Models;
using UMS.Infrastructure.Abstraction;
using UMS.Infrastructure.Abstraction.MailServices;

namespace UMSWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMailServicess _mailService;

    public UserController(IMediator mediator, IMailServicess mailService)
    {
        _mediator = mediator;
        _mailService = mailService;
    }

    [HttpPost("addUser")]
    public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("deleteUser")]
    public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPost("updateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("getAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _mediator.Send(new GetAllUsersQuerry()));
    }

    [HttpGet("{identifier}")]
    public async Task<IActionResult> GetUserById([FromRoute] int identifier)
    {
        return Ok(await _mediator.Send(new GetUserByIdQuerry()
        {
            UserId = identifier
        }));
    }

    [HttpGet("getUserByName")]
    public async Task<IActionResult> GetUserByName([FromQuery] string parameter)
    {
        return Ok(await _mediator.Send(new GetUsersByNameQuerry()
        {
            UserName = parameter
        }));
    }
}
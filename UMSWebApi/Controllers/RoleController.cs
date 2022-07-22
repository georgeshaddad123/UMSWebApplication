using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.Role.Command.AddRole;
using UMS.Application.Role.Command.DeleteRole;
using UMS.Application.Role.Command.UpdateRole;
using UMS.Application.Role.Querry.GetAllRoles;
using UMS.Application.Role.Querry.GetRoleById;

namespace UMSWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("addRole")]
    public async Task<IActionResult> AddRole(string name)
    {
        return Ok(await _mediator.Send(new AddRoleCommand()
        {
            Name = name
        }));
    }

    [HttpPost("updateRole")]
    public async Task<IActionResult> UpdateRole([FromQuery] int id, [FromQuery] string name)
    {
        return Ok(await _mediator.Send(new UpdateRoleCommand()
        {
            RoleId = id,
            RoleName = name
        }));
    }

    [HttpDelete("deleteRole")]
    public async Task<IActionResult> DeleteRole(DeleteRoleCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpGet("getAllRoles")]
    public async Task<IActionResult> GetAllRoles()
    {
        return Ok(await _mediator.Send(new GetAllRoleQuerry()));
    }

    [HttpGet("{identifier}")]
    public async Task<IActionResult> GetRoleById([FromRoute] int identifier)
    {
        return Ok(await _mediator.Send(new GetRoleByIdQuerry()
        {
            RoleId = identifier
        }));
    }
}
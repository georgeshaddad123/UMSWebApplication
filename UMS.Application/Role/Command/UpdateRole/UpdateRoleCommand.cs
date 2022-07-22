using MediatR;
using UMS.Application.DTO;

namespace UMS.Application.Role.Command.UpdateRole;

public class UpdateRoleCommand : IRequest<RoleDTO>
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
}
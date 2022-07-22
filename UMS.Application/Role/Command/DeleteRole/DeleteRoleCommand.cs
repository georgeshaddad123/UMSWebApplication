using MediatR;

namespace UMS.Application.Role.Command.DeleteRole;

public class DeleteRoleCommand : IRequest
{
    public int RoleId { get; set; }
}
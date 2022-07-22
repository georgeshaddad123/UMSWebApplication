using MediatR;

namespace UMS.Application.Role.Command.AddRole;

public class AddRoleCommand : Domain.Models.Role, IRequest<Domain.Models.Role>
{
    public Domain.Models.Role Role { get; set; }
}
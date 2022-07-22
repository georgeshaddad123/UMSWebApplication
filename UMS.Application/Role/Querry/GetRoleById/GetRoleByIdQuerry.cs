using MediatR;

namespace UMS.Application.Role.Querry.GetRoleById;

public class GetRoleByIdQuerry : IRequest<Domain.Models.Role>
{
    public int RoleId { get; set; }
}
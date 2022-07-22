using MediatR;
using UMS.Application.DTO;

namespace UMS.Application.Role.Querry.GetAllRoles;

public class GetAllRoleQuerry : IRequest<List<RoleDTO>>
{
}
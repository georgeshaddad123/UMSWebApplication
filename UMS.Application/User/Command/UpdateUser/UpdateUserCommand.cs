using MediatR;
using UMS.Application.DTO;

namespace UMS.Application.User.Command.UpdateUser;

public class UpdateUserCommand : IRequest<UserDTO>
{
    public long UId { get; set; }
    public string Name { get; set; }
    public long RoleId { get; set; }
    public string Email { get; set; }
}
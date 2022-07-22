using MediatR;
using UMS.Application.DTO;

namespace UMS.Application.User.Command.AddUser;

public class AddUserCommand : IRequest<UserDTO>
{
    public string Name { get; set; }
    public long RoleId { get; set; }
    public string Email { get; set; }
}
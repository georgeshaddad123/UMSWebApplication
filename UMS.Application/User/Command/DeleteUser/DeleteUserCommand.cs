using MediatR;

namespace UMS.Application.User.Command.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public int UserId { get; set; }
}
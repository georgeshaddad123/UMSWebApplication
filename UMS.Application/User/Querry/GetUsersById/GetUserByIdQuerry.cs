using MediatR;
using UMS.Application.DTO;

namespace UMS.Application.User.Querry.GetUsersById;

public class GetUserByIdQuerry : IRequest<UserDTO>
{
    public int UserId { get; set; }
}
using MediatR;
using UMS.Application.DTO;

namespace UMS.Application.User.Querry.GetAllUsers;

public class GetAllUsersQuerry: IRequest<List<UserDTO>>
{
}
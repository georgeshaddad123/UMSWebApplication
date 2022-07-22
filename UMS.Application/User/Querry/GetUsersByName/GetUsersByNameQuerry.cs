using MediatR;
using UMS.Application.DTO;

namespace UMS.Application.User.Querry.GetUsersByName;

public class GetUsersByNameQuerry : IRequest<List<UserDTO>>
{
    public string UserName { get; set; }
}
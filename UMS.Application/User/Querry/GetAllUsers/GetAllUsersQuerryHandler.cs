using AutoMapper;
using MediatR;
using UMS.Application.DTO;
using UMS.Persistence;

namespace UMS.Application.User.Querry.GetAllUsers;

public class GetAllUsersQuerryHandler : IRequestHandler<GetAllUsersQuerry, List<UserDTO>>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;

    public GetAllUsersQuerryHandler(UmsContext umsContext, IMapper mapper)
    {
        _umsContext = umsContext;
        _mapper = mapper;
    }
    public async Task<List<UserDTO>> Handle(GetAllUsersQuerry request, CancellationToken cancellationToken)
    {
        try
        {
            return _mapper.Map<List<UserDTO>>(_umsContext.Users.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
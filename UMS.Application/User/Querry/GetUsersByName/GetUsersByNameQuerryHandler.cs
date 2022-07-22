using AutoMapper;
using MediatR;
using UMS.Application.DTO;
using UMS.Persistence;

namespace UMS.Application.User.Querry.GetUsersByName;

public class GetUsersByNameQuerryHandler : IRequestHandler<GetUsersByNameQuerry, List<UserDTO>>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;

    public GetUsersByNameQuerryHandler(UmsContext umsContext, IMapper mapper)
    {
        _umsContext = umsContext;
        _mapper = mapper;
    }

    public async Task<List<UserDTO>> Handle(GetUsersByNameQuerry request, CancellationToken cancellationToken)
    {
        List<Domain.Models.User> listOfUsers = new List<Domain.Models.User>();
        try
        {
            var students = _umsContext.Users.Select(x=> x).ToList();
            listOfUsers = students.Where(x => x.Name.Contains(request.UserName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            return _mapper.Map<List<UserDTO>>(listOfUsers);
        }
        catch (Exception e)
        {
            Console.WriteLine("There's no one having the letter " + request.UserName);
        }

        return null;
    }
}
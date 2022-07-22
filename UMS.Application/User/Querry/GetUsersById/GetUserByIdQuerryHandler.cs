using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UMS.Application.DTO;
using UMS.Persistence;

namespace UMS.Application.User.Querry.GetUsersById;

public class GetUserByIdQuerryHandler : IRequestHandler<GetUserByIdQuerry, UserDTO>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;

    public GetUserByIdQuerryHandler(UmsContext umsContext, IMapper mapper)
    {
        _umsContext = umsContext;
        _mapper = mapper;
    }

    public async Task<UserDTO> Handle(GetUserByIdQuerry request, CancellationToken cancellationToken)
    {
        Domain.Models.User? user = new Domain.Models.User();
        try
        {
            user = await _umsContext.Users.Where(x => x.Id == request.UserId).FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine("The id given is not found");
        }

        return _mapper.Map<UserDTO>(user);
    }
}
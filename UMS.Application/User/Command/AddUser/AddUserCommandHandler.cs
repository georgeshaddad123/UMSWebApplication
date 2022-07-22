using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UMS.Application.DTO;
using UMS.Persistence;

namespace UMS.Application.User.Command.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserDTO>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;

    public AddUserCommandHandler(UmsContext umsContext, IMapper mapper)
    {
        _umsContext = umsContext;
        _mapper = mapper;
    }

    public async Task<UserDTO> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.User user = new Domain.Models.User()
        {
            RoleId = request.RoleId,
            Email = request.Email,
            Name = request.Name,
            KeycloakId = Guid.NewGuid().ToString(),
        };
        try
        {
            _umsContext.Users.Add(user);
            await _umsContext.SaveChangesAsync();
            user = await _umsContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == request.RoleId);
            return _mapper.Map<UserDTO>(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
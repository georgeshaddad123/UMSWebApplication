using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UMS.Application.DTO;
using UMS.Persistence;

namespace UMS.Application.User.Command.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDTO>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(UmsContext umsContext, IMapper mapper)
    {
        _umsContext = umsContext;
        _mapper = mapper;
    }

    public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Models.User user = await _umsContext.Users.Where(r => r.Id.Equals(request.UId)).FirstAsync();
            user.Id = request.UId;
            user.Name = request.Name;
            user.Email = request.Email;
            user.RoleId = request.RoleId;
            await _umsContext.SaveChangesAsync(cancellationToken);
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
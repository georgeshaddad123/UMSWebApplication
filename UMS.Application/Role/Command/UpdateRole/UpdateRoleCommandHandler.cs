using AutoMapper;
using MediatR;
using UMS.Application.DTO;
using UMS.Persistence;

namespace UMS.Application.Role.Command.UpdateRole;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand ,RoleDTO>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(UmsContext umsContext, IMapper mapper)
    {
        _umsContext = umsContext;
        _mapper = mapper;
    }

    public async Task<RoleDTO> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Models.Role role = _umsContext.Roles.Where(r => r.Id.Equals(request.RoleId)).First();
            role.Name = request.RoleName;
            await _umsContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<RoleDTO>(role);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
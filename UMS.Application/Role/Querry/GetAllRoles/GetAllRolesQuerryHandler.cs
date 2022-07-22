using AutoMapper;
using MediatR;
using UMS.Application.DTO;
using UMS.Persistence;

namespace UMS.Application.Role.Querry.GetAllRoles;

public class GetAllRoleQuerryHandler : IRequestHandler<GetAllRoleQuerry, List<RoleDTO>>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;

    public GetAllRoleQuerryHandler(UmsContext postgresContext, IMapper mapper)
    {
        _umsContext = postgresContext;
        _mapper = mapper;
    }

    public async Task<List<RoleDTO>> Handle(GetAllRoleQuerry request, CancellationToken cancellationToken)
    {
        try
        {
            return _mapper.Map<List<RoleDTO>>(_umsContext.Roles.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
using MediatR;
using UMS.Persistence;

namespace UMS.Application.Role.Querry.GetRoleById;

public class GetRoleByIdQuerryHandler : IRequestHandler<GetRoleByIdQuerry, Domain.Models.Role>
{
    private readonly UmsContext _umsContext;

    public GetRoleByIdQuerryHandler(UmsContext umsContext)
    {
        _umsContext = umsContext;
    }

    public async Task<Domain.Models.Role> Handle(GetRoleByIdQuerry request, CancellationToken cancellationToken)
    {
        Domain.Models.Role role = new Domain.Models.Role();
        try
        {
            role = _umsContext.Roles.Where(x => x.Id == request.RoleId).FirstOrDefault();
        }
        catch (Exception e)
        {
            Console.WriteLine("The id given is not found");
        }

        return role;
    }
}
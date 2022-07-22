using MediatR;
using UMS.Persistence;

namespace UMS.Application.Role.Command.AddRole;

public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Domain.Models.Role>
{
    private readonly UmsContext _umsContext;

    public AddRoleCommandHandler(UmsContext umsContext)
    {
        _umsContext = umsContext;
    }

    public async Task<Domain.Models.Role> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _umsContext.Roles.Add(request);
            _umsContext.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return request.Role;
    }
}
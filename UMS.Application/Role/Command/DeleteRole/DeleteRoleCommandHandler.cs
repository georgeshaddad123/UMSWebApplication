using MediatR;
using UMS.Persistence;

namespace UMS.Application.Role.Command.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly UmsContext _umsContext;

    public DeleteRoleCommandHandler(UmsContext umsContext)
    {
        _umsContext = umsContext;
    }

    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Models.Role role = _umsContext.Roles.Where(r => r.Id == request.RoleId).FirstOrDefault();
            _umsContext.Roles.Remove(role);
            _umsContext.SaveChanges();
            return Unit.Value;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
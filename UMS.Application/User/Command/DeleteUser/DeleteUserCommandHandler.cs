using MediatR;
using Microsoft.EntityFrameworkCore;
using UMS.Persistence;

namespace UMS.Application.User.Command.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly UmsContext _umsContext;

    public DeleteUserCommandHandler(UmsContext umsContext)
    {
        _umsContext = umsContext;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Models.User user = await _umsContext.Users.Where(r => r.Id == request.UserId).FirstOrDefaultAsync();
            _umsContext.Users.Remove(user);
            await _umsContext.SaveChangesAsync();
            return Unit.Value;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
using AutoMapper;
using MediatR;
using UMS.Persistence;

namespace UMS.Application.SessionTime.Command.AddSessionTime;

public class AddSessionTimeCommandHandler : IRequestHandler<AddSessionTimeCommand, Domain.Models.SessionTime>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;

    public AddSessionTimeCommandHandler(UmsContext umsContext, IMapper mapper)
    {
        _umsContext = umsContext;
        _mapper = mapper;
    }

    public async Task<Domain.Models.SessionTime> Handle(AddSessionTimeCommand request,
        CancellationToken cancellationToken)
    {
        Domain.Models.SessionTime sessionToAdd = new Domain.Models.SessionTime();
        sessionToAdd.StartTime = request.StartTime;
        sessionToAdd.EndTime = request.EndTime;
        await _umsContext.SessionTimes.AddAsync(sessionToAdd, cancellationToken);
        await _umsContext.SaveChangesAsync(cancellationToken);
        return sessionToAdd;
    }
}
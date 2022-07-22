using System.Diagnostics;
using MediatR;

namespace UMSWebAPI.Behaviors;

public class TimerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TimerBehavior<TRequest, TResponse>> _logger;

    public TimerBehavior(ILogger<TimerBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var timer = new Stopwatch();
        timer.Start();
        var response = await next();
        timer.Stop();
        return response;
    }
}
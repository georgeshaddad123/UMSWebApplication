using UMSWebAPI.Middlewares;

namespace UMSWebAPI.Configuration;

public static class TimingMiddlewareConfiguration
{
    public static IApplicationBuilder RegisterTimingMiddleware(this WebApplication app)
    {
        return app.UseMiddleware<TimingMiddleware>();
    }
}
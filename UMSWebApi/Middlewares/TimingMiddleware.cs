namespace UMSWebAPI.Middlewares;

public class TimingMiddleware
{
    private readonly RequestDelegate _next;

    public TimingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        Console.WriteLine("Date: " + DateTime.Now.ToLongDateString());
        return _next(httpContext);
    }
}
namespace Logging2.Middlewares
{
    public class FirstMiddleware: IMiddleware
    {
        // use ILogger like normal (ie log to console)
        public ILogger Logger { get; set; }
        public FirstMiddleware(ILogger<FirstMiddleware> logger)
        {
            Logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // log to Seq at different levels, see appsettings.Development.json for configuration
            this.Logger.LogInformation("FirstMiddleware Log InvokeAsync");
            this.Logger.LogTrace(35, "Trace: {p1} and {p2}", "Param1", "Param2");
            this.Logger.LogDebug(35, "Debug: {p1} and {p2}", "Param1", "Param2");
            this.Logger.LogWarning(35, "Warning: {p1} and {p2}", "Param1", "Param2");
            this.Logger.LogError(900, "Error: {p1} and {p2}", "Param1", "Param2");
            this.Logger.LogCritical(8, "Critical: {p1} and {p2}", "Param1", "Param2");
            await next(context);
        }
    }
}

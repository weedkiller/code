    public class RequestResponseLoggingMiddleware : IMiddleware
    {
        IActionLogPublish logPublish;
    
        public RequestResponseLoggingMiddleware(IActionLogPublish logPublish)
        {
            _logPublish = logPublish;
        }
    
    ...
    
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
    ...
        }
    
    ...
    }

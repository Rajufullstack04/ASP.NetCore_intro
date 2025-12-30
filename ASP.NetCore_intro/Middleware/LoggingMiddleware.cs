namespace ASP.NetCore_intro.Middleware
{
    public class LoggingMiddleware
    {

        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log incoming request
            Console.WriteLine("********** Incoming Request **********");
            Console.WriteLine($"Method: {context.Request.Method}");
            Console.WriteLine($"Path: {context.Request.Path}");
            Console.WriteLine($"Headers: {context.Request.Headers}");
            // Call the next middleware in the pipeline
            await _next(context);
            // Log outgoing response
            Console.WriteLine("********** Outgoing Response **********");
            Console.WriteLine($"Status Code: {context.Response.StatusCode}");
        }
















    }
}

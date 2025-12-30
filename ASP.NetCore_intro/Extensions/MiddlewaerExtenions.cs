using ASP.NetCore_intro.Middleware;

namespace ASP.NetCore_intro.Extensions
{
    public static class MiddlewaerExtenions 
    {

        public static IApplicationBuilder UseHttpContextMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpContextMiddleware>();

        }

       public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }





    }
}

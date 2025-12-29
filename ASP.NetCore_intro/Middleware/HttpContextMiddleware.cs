using System.Reflection.PortableExecutable;

namespace ASP.NetCore_intro.Middleware
{
    public class HttpContextMiddleware
    {
        RequestDelegate _next;
        public HttpContextMiddleware(RequestDelegate next) 
        { 
            _next = next;

        }

        // logic 
        // I want to write the logic for get the Headers of the context ,path ,body etc...
        // I want to write the logic for to append the headers to the responce....




        public async Task InvokeAsync(HttpContext context)
        {
            var header = context.Request.Headers;
            var body = context.Request.Body;
            var path = context.Request.Path;


            Console.WriteLine("********** Incoming Request **********");
            Console.WriteLine($"Path: {path}");
            Console.WriteLine($"Headers: {header}");












            await _next(context);





            Console.WriteLine("heelow orld");

            Console.WriteLine("********** Outgoing Response **********");
            Console.WriteLine($"Status Code: {context.Response.StatusCode}");

            context.Response.OnStarting(() =>

            {
                //context.Response.Headers.Append("X-App-Name", "HttpContextDemoController");
                //context.Response.Headers.Append("X-Devloper", "Raju");

                context.Response.Headers["X-App-Name"] = "HttpContextDemoController";
                context.Response.Headers["X-Devloper"] = "Raju";


                return Task.CompletedTask;
            });

        }


    }
}

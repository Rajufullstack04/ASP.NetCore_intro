namespace ASP.NetCore_intro.Middleware
{
    public class JWTAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {

           bool isLoginPath = context.Request.Path.ToString().Contains("Login");

             if (isLoginPath)
            {
                // if the request is for the login path, skip JWT authanetication

                await _next(context);
                return;

            }
            else
            {
                // please give your JWT token 

            }

            
        }
    }
}

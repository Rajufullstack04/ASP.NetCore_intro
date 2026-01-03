using ASP.NetCore_intro.Contracts;

namespace ASP.NetCore_intro.Middleware
{
    public class JWTAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IJWTAuthentication _jWTAuthentication;
        public JWTAuthenticationMiddleware(RequestDelegate next , IJWTAuthentication jWTAuthentication )
        {
            _next = next;

            _jWTAuthentication = jWTAuthentication;
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
              var AuthorizationKey =  context.Request.Headers["Authorization"].ToString();
                // please give your JWT token 

              bool isUserValid =  _jWTAuthentication.ValidateJWTToken(AuthorizationKey);

                if (isUserValid )
                {
                    await _next(context);
                }
                else
                {
                    context.Response.Headers["Token-Status"] = "Invalid or Expired Token";
                    return;
                }




            }

            
        }
    }
}

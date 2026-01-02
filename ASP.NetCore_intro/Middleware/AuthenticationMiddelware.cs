using ASP.NetCore_intro.Contracts;
using Microsoft.AspNetCore.Authentication;

namespace ASP.NetCore_intro.Middleware
{
    public class AuthenticationMiddelware
    {

        RequestDelegate _next;
        IAuthenticateService athunticateService;

        public AuthenticationMiddelware( RequestDelegate next,IAuthenticateService athunticateService)
        {
            _next = next;
            this.athunticateService = athunticateService;
        }




        public async Task InvokeAsync(HttpContext context)
        {
            //Extract Token from Header
            var token = context.Request.Headers["Authorization"].ToString(); // token from Autherizon heaer
           
            
            
            
            if (token != null)
            {

              bool isValid =  athunticateService.ValidateToken(token);
                if(isValid)
                {
                    await _next(context);
                    return;
                }

                // validate the token
                //This is just a placeholder logic for validation
                //if (token == "rajudfnehfi3@^&BUHOfjvjnn&&hhs")
                //{
                ////    //Token is valid, proceed to the next middleware
                //   await _next(context);
                //   return;
                //} 

            }
            //Token is invalid or missing, return 401 Unauthorized

            context.Response.StatusCode = 401; // Unauthorized
            context.Response.Headers["TokenStatus"] = "Invalid or Missing Token";





        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP.NetCore_intro.Fillters
{
    public class RequireGmailAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var email = context.HttpContext.Request.Headers["email"].ToString();

            if (string.IsNullOrEmpty(email) || email.EndsWith("@gmail.com") == false)
            {
                context.Result = new BadRequestObjectResult("Only Gmail adderses are allowed");
                return;
            }
            else
            {

            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var email = context.HttpContext.Request.Headers["email"].ToString();

            var now = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            context.HttpContext.Response.Headers["X-Email"]= email;

            context.HttpContext.Response.Headers["X-crrent-time"]= now;


        }
    }
}

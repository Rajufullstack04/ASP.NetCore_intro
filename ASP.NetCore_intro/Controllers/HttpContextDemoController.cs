using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ASP.NetCore_intro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpContextDemoController:ControllerBase
    {
        public HttpContextDemoController() 
        {
            Console.WriteLine("httpcontextdemocontroller instantiated");
        
        }





        //https://localhost:7049/api/HttpContextDemo/ShowContext/101

        [HttpPost("ShowContext/{Id}")]

        public IActionResult ShowContexxt(
            int Id,                                                            // FromRoute
            [FromQuery] int age,                                               // FromQuery
            [FromQuery] string location,                                      // FromQuery
            [FromBody] UserDTO userDTO,                                       // FromBody                  
            [FromHeader ( Name = "MyTechnologie")] string Technologie)        // FromHeader
        {

            var context = HttpContext;

              var header =  context.Request.Headers;
              var body =  context.Request.Body;
              var path = context.Request.Path;

            //HttpContext.Response.Headers.Append("X-App-Name", "HttpContextDemoController");
            //HttpContext.Response.Headers.Append("X-Devloper", "Raju");

            


            return Ok(new
            {
                RouteId   = Id,
                Queryage = age,
                Quarylocation = location,
                User = userDTO,
                MyTechnologie = Technologie,
                Requestheader = header.Keys,
                Requestpath = path,

                message = "Headers added successfully",

            });




        }





    }

    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }





}

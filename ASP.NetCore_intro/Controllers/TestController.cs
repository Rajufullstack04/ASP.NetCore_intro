using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore_intro.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    // https://localhost:7049/api/test/hello
    public class TestController : ControllerBase
    {
        public TestController()
        {
            Console.WriteLine("TestController instantiated");
        }



        [HttpGet("hello")]
        public IActionResult GetHello()
        {
            return Ok("Hello, World!");
        }
    }
}

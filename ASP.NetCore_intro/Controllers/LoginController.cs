using ASP.NetCore_intro.Services1;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore_intro.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class LoginController: Controller
    {
        IAuthenticateService _authenticateService;
        public LoginController(IAuthenticateService authenticateService) 
        {
            _authenticateService = authenticateService;

        }




        [HttpPost("LoginUser")]

        // endpoint: https://localhost:7049/api/Login/LoginUser
        public IActionResult LoginUser([FromBody] LoginRequest request)
        {
            // Here you would typically validate the user credentials against a database
            if (request.Username == "Raju" && request.Password == "raju$52141")
            {

                var token = _authenticateService.GenerateToken(request.Username, request.Password);
                return Ok(new { Token = token });
                 

                //return Ok(new { Token = "fake-jwt-token" });
            }
            return Unauthorized();
        }



        // https://localhost:7049/api/Login/GetCustomers
        [HttpGet]
        [Route("GetCustomers")]
        public IActionResult GetCustomers()
        {
            var customers = new[]
            {
                new { Id = 1, Name = "Raju" },
                new { Id = 2, Name = "Venky" },
                new { Id = 3, Name = "Adarsh" }
            };
            return Ok(customers);
        }
       





        //[HttpPost("ValidateUser")]
        //public IActionResult ValidateUser([FromBody] LoginRequest request)
        //{
        //    bool isValid = _authenticateService.ValidateUser(request.Username, request.Password);
        //    if (isValid)
        //    {
        //        return Ok(new { Message = "User is valid" });
        //    }
        //    return Unauthorized(new { Message = "Invalid user" });
        //}




    }


    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

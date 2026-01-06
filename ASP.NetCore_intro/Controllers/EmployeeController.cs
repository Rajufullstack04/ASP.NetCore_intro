using ASP.NetCore_intro.Fillters;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore_intro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        public DepartmentController()
        {
            var ab = 10;
        }

            
        [RequireGmailAttribute]
        [HttpGet("GetDepartmentEmail1")]
        // endpoint : https://localhost:7049/api/Department/GetDepartmentEmail1 
        public IActionResult GetDepartmentEmail1()
         {
        //    if (string.IsNullOrEmpty(email1) || email1.EndsWith("@gmail.com") == false)
        //    {
        //        return BadRequest("Invalid email domain. Only gmail.com is allowed.");
        //    }

            var message = "Department employee validated with a proper Gmail account.";
            return Ok(new { MyMessage = message});
        }


        [RequireGmail]
        [HttpGet("GetDepartmentEmail2")]
        
        public IActionResult GetDepartmentEmail2()
        {
            //if (string.IsNullOrEmpty(email2) || email2.EndsWith("@gmail.com") == false)
            //{
            //    return BadRequest("Invalid email domain. Only gmail.com is allowed.");
            //}

            var message = "Department employee validated with a proper Gmail account.";
            return Ok(new { MyMessage = message});
        }


        [RequireGmail]
        [HttpGet("GetDepartmentEmail3")]
       
        public IActionResult GetDepartmentEmail3()
        {
            //if (string.IsNullOrEmpty(email3) || email3.EndsWith("@gmail.com") == false)
            //{
            //    return BadRequest("Invalid email domain. Only gmail.com is allowed.");
            //}

            var message = "Department employee validated with a proper Gmail account.";
            return Ok(new { MyMessage = message });
        }
    }
}

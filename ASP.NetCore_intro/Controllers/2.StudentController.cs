using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace ASP.NetCore_intro.Controllers
{

    // we have to design the endpoint to manage the student entity
    //step1:We have to create a API controler atribute
    // step2 :we have to create route attribute for the controller design for the base path of the controller

    [ApiController]

    [Route("api/[controller]")]    // https://localhost:7049/api/StudetntV2
    public class StudetntV2Controller : ControllerBase
    {
        public StudetntV2Controller() { }


        //---------------------api/StudetntV1/Student2----  this is called URI of resourece--------


        [HttpGet]
        [Route("Student1")] //  https://localhost:7049/api/StudetntV2/Student1
        public string GetStudentName_1()
        {
            return "Raju-v1";
        }



        [HttpGet]
        [Route("Student2")]  //  https://localhost:7049/api/StudetntV2/Student2
        public string GetStudentName_2()
        {
            return "Venky-v1";
        }

        // 
        [HttpGet]
        [Route("Student3")]  //  https://localhost:7049/api/StudetntV2/Student3
        public async Task<IActionResult> GetStudentName_3()
        {
            await Task.Delay(1000);

            string studentname = null;

            if (studentname == null)
            {
                // return NotFound("No student found");
                return BadRequest("No student found");
            }
            else
            {
                return Ok("Ravi-v1");
            }

        }

    }
}

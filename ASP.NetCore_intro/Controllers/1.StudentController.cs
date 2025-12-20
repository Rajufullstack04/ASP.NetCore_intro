using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace ASP.NetCore_intro.Controllers
{

    // we have to design the endpoint to manage the student entity
    //step1:We have to create a API controler atribute
    // step2 :we have to create route attribute for the controller design for the base path of the controller

    [ApiController]

    [Route("api/[controller]")]    // https://localhost:7049/api/StudetntV1
    public class StudetntV1Controller : ControllerBase
    {
      public StudetntV1Controller() { }


        //---------------------api/StudetntV1/Student2----  this is called URI of resourece--------


        [HttpGet]
    [Route("Student1")] //  https://localhost:7049/api/StudetntV1/Student1
        public string GetStudentName_1()
    {
        return "Raju-v1";
    }

       

        [HttpGet]
        [Route("Student2")]  //  https://localhost:7049/api/StudetntV1/Student2
        public string GetStudentName_2()
        {
            return "Venky-v1";
        }

        // 
      
     }
        
        
 }


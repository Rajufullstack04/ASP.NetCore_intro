using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore_intro.Controllers
{


    [ApiController]
    [Route("api/[controller]")]     // https://localhost:7049/api/StudetntV3

    public class StudetntV3Controller : ControllerBase
    {
        public StudetntV3Controller() { }




        [HttpGet]
        [Route("List")]     // https://localhost:7049/api/StudetntV3/List
        public async Task<IActionResult> GetStudentList()
        {
            var StudentList = await GetStudentens();
            if (StudentList == null || StudentList.Count == 0)
            {
                return NotFound("NO STUDENTS FOUND");
            }
            else
            {
                return Ok(StudentList);
            }

        }





        [HttpGet]
        [Route("ListByID/{id:int}")]     // https://localhost:7049/api/StudetntV3/ListByID/101
        public async Task<IActionResult> GetStudentList_ByID(int ID)
        {
            var StudentList = await GetStudentens();


          var stu =  StudentList.Where(stu => stu.StuID == ID);

            if (stu == null )
            {
                return NotFound("NO STUDENTS FOUND");
            }
            else
            {
                return Ok(stu);
            }

        }






        [HttpGet]
        [Route("ListByFee/{fee:double}")]     // https://localhost:7049/api/StudetntV3/ListByFee/6000
        public async Task<IActionResult> GetStudentList_ByLocation(double fee)
        {
            var StudentList = await GetStudentens();


            var stu = StudentList.Where(stu => stu.StuFee <= fee);

            if (stu == null)
            {
                return NotFound("NO STUDENTS FOUND");
            }
            else
            {
                return Ok(stu);
            }

        }






        [HttpGet]
        [Route("ListByIDAndFEE/{ID:int}/{fee:double}")]

        // https://localhost:7049/api/StudetntV3/ListByIDAndFEE/101/6000


        public async Task<IActionResult> GetStudentList_ByIDAndFEE(int id , double fee)
        {
            var StudentList = await GetStudentens();


            var stu = StudentList.Where(stu => stu.StuFee >= fee && stu.StuID == id);

            if (stu == null || stu.Count() == 0 )
            {
                return NotFound("NO STUDENTS FOUND");
            }
            else
            {
                return Ok(stu);
            }

        }































        private async Task<List<Student>> GetStudentens()
        {
            await Task.Delay(2000);
            List<Student> students = new List<Student>()
            {
                new Student() { StuID=101 ,StuNAME="Raju",StuLocation="Kadiri",StuCource="Js",StuFee=6000},
                new Student() { StuID = 102, StuNAME = "Venky", StuLocation = "Anathapur", StuCource = "Angular",StuFee=7000 },
                new Student() { StuID = 101, StuNAME = "Adarsh", StuLocation = "Kadiri", StuCource = "C#",StuFee=75000 },
                new Student() { StuID = 104, StuNAME = "Ravi", StuLocation = "HYB", StuCource = "ASP.NETCore",StuFee=25000 },
            };
            return students;
        }





    }
    //-------------------------------------------------------------
    public class Student
    {
        public int StuID { get; set; }
        public string StuNAME { get; set; }

        public string StuLocation { get; set; }
        public string StuCource { get; set; }

        public double StuFee { get; set; }

    }



}

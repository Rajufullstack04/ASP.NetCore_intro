
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore_intro.Controllers
{


    [ApiController]
    [Route("api/[controller]")]     // https://localhost:7049/api/StudetntV4

    public class StudetntV4Controller : ControllerBase
    {
        public StudetntV4Controller() { }

        // 

        // post meens you are passing the same data(body) throught url then you have to give the same responce......


        [HttpPost]
        [Route("GetStudentListBysampulStudentWithQuary")]
        // https://localhost:7049/api/StudetntV4/GetStudentListBysampulStudentWithQuary?Name=Raju&location=Kadiri&Fee


        public async Task<IActionResult> GetStudentListBysampulStudentWithQuary([FromBody] StudentDTO studentDTO)
        {
            // i am not insarting the data here i am trying to taking the values from the body .......by using post method....


            var StudentList = await GetStudentens();
            var result = StudentList.Where(stu => stu.StuLocation == studentDTO.location && stu.StuFee >= studentDTO.Fee && stu.StuNAME == studentDTO.Name);
            if (!result.Any())
            {
                return NotFound($"no students found with fee and location {studentDTO.location} Name {studentDTO.Name} Fee {studentDTO.Fee}");    // 404 not fond
            }
            else
            {
                return Ok(result);
            }

        }


        //--------------------------------------------Inserting the data by post method-------------------------------




        [HttpPost]
        [Route("AddNewStudent")]

        // https://localhost:7049/api/StudetntV4/AddNewStudent

        public async Task<IActionResult> AddNewStudent([FromBody] StudentDTO studentDTO)
        {

            await Task.Delay(1000);
            if (studentDTO == null)
            {
                return BadRequest("student data is null");
            }

            //// semulate adding new student data ( in real application you shoud save in database)
            //Student newstudent = new Student()
            //{
            //    StuID = 205,
            //    StuNAME = studentDTO.Name,
            //    StuLocation = studentDTO.location,
            //    StuCource = "C#",
            //    StuFee = studentDTO.Fee
            //};

            NewstudentResponceDTO newstudentResponce = new NewstudentResponceDTO()
            {
                StuID = new Random().Next(100, 500), // showing random id number
                StuName = studentDTO.Name
            };




            // here you wold typicaly add the newstudent to your data store
            return Created("https://localhost:7049/api/StudetntV4/AddNewStudent", newstudentResponce);
            // we can pass ok masg allso but thing is user has to understand if the student is added or not .


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
                new Student() { StuID = 105, StuNAME = "Ramu", StuLocation = "HYB", StuCource = "Java",StuFee=25000 },
            };
            return students;
        }









        public class Student
        {
            public int StuID { get; set; }
            public string StuNAME { get; set; }

            public string StuLocation { get; set; }
            public string StuCource { get; set; }

            public double StuFee { get; set; }

        }

        // Quary parames declaring in a class -----------------------------------

        public class StudentDTO
        {
            public string Name { get; set; }

            public string location { get; set; }

            public double Fee { get; set; }
        }

        // we will tack anther responce for post methd

        public class NewstudentResponceDTO
        {
            public int StuID { get; set; }
            public string StuName { get; set; }


        }
    }
}
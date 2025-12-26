
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore_intro.Controllers
{


    [ApiController]
    [Route("api/[controller]")]     // https://localhost:7049/api/StudetntV5

    public class StudetntV5Controller : ControllerBase
    {
        // public StudetntV5Controller() { }

        // Put method
        // // if want to update the record we use Put method


        [HttpPut]
        [Route("UpdateStudent/{id}")]

        // https://localhost:7049/api/StudetntV5/UpdateStudent

        // in genraly we use put method for update the all data in the record--

        // let exampule we have some values if we wantb to update the values we use out method...
        public async Task<IActionResult> UpdateStudent([FromRoute] int id,[FromBody] StudentDTO studentDTO)
        {
           // await Task.Delay(1000);
          var studentlist = await GetStudentens();

            //var student = studentlist.Where(U => U.StuID == id).First();


            // studentlist.First(u => u.StuID == id);

          var student =  studentlist.FirstOrDefault(U => U.StuID == id);
            if (student != null)
            {
                student.StuLocation = studentDTO.location;
                student.StuNAME = studentDTO.Name;
                student.StuFee = studentDTO.Fee;

                return Ok($"Student has updated successfully now :.\nName:{student.StuNAME}.\nStuFee:{student.StuFee}.\nStudentLoc:{student.StuLocation}");
            }
            else
            {
                return BadRequest($"You are passing the worng details.Please chek your request");
            }
        }


        // pacth method wich is related to update the limited data 

        [HttpPatch]
        [Route("UpdateStudentWithNAME/{id}")]

        // https://localhost:7049/api/StudetntV5/UpdateStudentWithNAME/101


        public async Task<IActionResult> UpdateStudentWithNAME([FromRoute] int id, [FromBody] NewstudentResponceDTO newstudentDTO)
        {
            // await Task.Delay(1000);
            var studentlist = await GetStudentens();

            //var student = studentlist.Where(U => U.StuID == id).First();


            // studentlist.First(u => u.StuID == id);

            var student = studentlist.FirstOrDefault(U => U.StuID == id);
            if (student != null)
            {

                student.StuNAME = newstudentDTO.StuName;
              

                return Ok($"Student has updated successfully now :.\nName:{student.StuNAME}.\nStuFee:{student.StuFee}.\nStudentLoc:{student.StuLocation}");
            }
            else
            {
                return BadRequest($"You are passing the worng details.Please chek your request");
            }
        }

        // delete method ----> for remove data from the database---------

        [HttpDelete("DeleteStudent/{Id}")]
     
        //  https://localhost:7049/api/StudetntV5/DeleteStudent/101
        public async Task<IActionResult> DeleteStudent([FromRoute] int Id)
        {
            var studentlist = await GetStudentens();
            var student = studentlist.FirstOrDefault(D => D.StuID==Id);
            
            if(student != null)
            {
                studentlist.Remove(student);
                return Ok($"the studentdeteils are deleted by this ID:{student.StuID}");
            }
            return BadRequest("the request invalid by this id we dont have detalies ");
        }













        private async Task<List<Student>> GetStudentens()
        {
            await Task.Delay(2000);
            List<Student> students = new List<Student>()
            {
                new Student() { StuID=101 ,StuNAME="Raju",StuLocation="Kadiri",StuCource="Js",StuFee=6000},
                new Student() { StuID = 102, StuNAME = "Venky", StuLocation = "Anathapur", StuCource = "Angular",StuFee=7000 },
                new Student() { StuID = 103, StuNAME = "Adarsh", StuLocation = "Kadiri", StuCource = "C#",StuFee=75000 },
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
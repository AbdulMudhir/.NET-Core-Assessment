using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _NET_Core_Assessment.DataAccessLibrary.BusinessLogic;
using _NET_Core_Assessment.Models;
using _NET_Core_Assessment.Models.PostModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _NET_Core_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly StudentManager _studentManager;
        private readonly ClassroomManager _classroomManager;

        public StudentController(StudentManager studentManager, ClassroomManager classroomManager)
        {
            _studentManager = studentManager;
            _classroomManager = classroomManager;
        }




        //api/student/
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentPostModel student)
        {
            if(ModelState.IsValid)
            {
                // this validation can be removed as some students would have the same name and can be in same class rom

                var studentDB = await _studentManager.GetStudent(student);

                if(studentDB == null)
                {

                    var classroomDb = await _classroomManager.GetClassById(student.ClassId);
                    
                    if(classroomDb != null)
                    {
                        var studentModel = new StudentModel {
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            Age = student.Age,
                            ClassId = classroomDb.ClassId
                        };

                        var studentID = await _studentManager.AddStudent(studentModel);

                        return Ok("Student has been added");
                        
                    }

                    return NotFound("Classroom does not exist. Student cannot be added without classroom");
                    
                }

                return Ok("Student Already Exist");

            }

            return NotFound();
        }

     
   
    }
}

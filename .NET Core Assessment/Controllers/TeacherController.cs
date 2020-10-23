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
    public class TeacherController : ControllerBase
    {
        private readonly TeacherManager _teacherManager;
        private readonly ClassroomManager _classroomManager;

        public TeacherController(TeacherManager teacherManager, ClassroomManager classroomManager)
        {
            _teacherManager = teacherManager;
            _classroomManager = classroomManager;
            
        }

        //api/teacher
        [HttpPost]
        public async Task <IActionResult> AddTeacher([FromBody] TeacherPostModel teacher)
        {
            if (ModelState.IsValid)
            {
              
                // check if the teacher already exist if it does , return teacher object or null
                var teacherDB = await _teacherManager.GetTeacher(teacher);

                if (teacherDB == null)
                {
                    var teacherToAddDB = new TeacherModel()
                    {
                        FirstName= teacher.FirstName,
                        LastName = teacher.LastName,
                        Age = teacher.Age,
                        Subject = teacher.Subject
                    };

                    var teacherID = await _teacherManager.AddTeacher(teacherToAddDB);

                    return Ok($"Teacher has been added to database - ID {teacherID}");


                }

                return Ok($"Teacher Already Exist - TeacherID: {teacherDB.TeacherId}");

            }

            return NotFound();
        }

        //api/teacher/class
        [HttpPost("class")]
        public async Task<IActionResult> AddTeacherToClass(TeacherClassPostModel teacherClassPostModel)
        {
           
            if(ModelState.IsValid)
            {
                var teacher = await _teacherManager.GetTeacherById(teacherClassPostModel.TeacherId);

                if(teacher == null)
                {
                    return NotFound("Teacher not found");
                }

                var classroom = await _classroomManager.GetClassById(teacherClassPostModel.ClassId);

                if(classroom == null)
                {
                    return NotFound("Classroom not found");
                }

                var teacherAssignedToClass =
                   await  _teacherManager.GetTeacherIDByClassId(teacher.TeacherId, classroom.ClassId);

                if(teacherAssignedToClass == null)
                {
                  
                    var updatedRow = await _teacherManager.AddTeacherIDByClassId
                        (teacherClassPostModel.TeacherId, teacherClassPostModel.ClassId);

                    return Ok("Teacher has been added");  
                }

                return Ok("Teacher with that ID has already been assigned to the class");

            }


            return NotFound();
        }


    }
}

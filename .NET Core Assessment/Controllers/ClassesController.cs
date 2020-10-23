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
    [Route("api/class")]
    [ApiController]
    public class ClassesController : ControllerBase
    {

        private readonly ClassroomManager _classroomManager;

        public ClassesController(ClassroomManager classroomManager)
        {
            _classroomManager = classroomManager;
     

        }

       //api/classes/
        [HttpPost]
        public async Task< IActionResult> CreateClass([FromBody] ClassPostModel classModel)
        {
            if(ModelState.IsValid)
            {
                // check if the class already exist if it does , return class object or null
                var classDB = await _classroomManager.GetClass(classModel);

                if(classDB == null)
                {
                    var classToAdd = new ClassModel()
                    { ClassName = classModel.ClassName, School = classModel.School = classModel.School,
                        Grade = classModel.Grade };

                    var classID = await _classroomManager.AddClass(classToAdd);

                    return Ok($"Class has been added to database");


                }

                return Ok($"Class Already Exist");

            }

            return NotFound();
        }

        //api/classes/students?className
        [HttpGet("students/{string}")]
        public async Task<IActionResult> GetAllStudentsByClassname(string className)
        {
           
                // check if the class already exist if it does , return class object or null
                var classDB = await _classroomManager.GetClassByName(className);

                if (classDB != null)
                {
                   
                    var students = await _classroomManager.GetAllStudentsFromClassName(className);

                    return Ok(students);


                }

                return NotFound("Classroom not found");


        }

        //api/classes
        [HttpGet]
        public async Task<IActionResult> GetAllClassRoomNames()
        {
            var data = await _classroomManager.GetAllClassesByName();

            return new JsonResult( data);
        }


  


    }
}

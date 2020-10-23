using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _NET_Core_Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _NET_Core_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly List<ClassModel> _dummyData;

        public ClassController()
        {
            _dummyData = new List<ClassModel>() {
            new ClassModel() { ClassId = 1, ClassName= "ICT",School= "Hackney", Grade= "A+" },
            new ClassModel() { ClassId = 2, ClassName = "SCIENCE", School = "Hackney", Grade = "A+" },
            new ClassModel() { ClassId = 3, ClassName = "P.E", School = "Hackney", Grade = "A+" }

            };

        }


        [HttpPost]
        public IActionResult Create([FromBody] ClassPostModel classModel)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddTeacher([FromBody] TeacherModel teacher)
        {
            return Ok();
        }

        [HttpGet("GetAllClassRoomNames")]
        public IActionResult GetAllClassRoomNames()
        {
            return new JsonResult( _dummyData.Select(d => d.ClassName));
        }

        [HttpGet("GetAllStudentsFromClassRoomId")]
        public IActionResult GetAllStudentsFromClassRoomId(int classroomID)
        {
            return Ok();
        }
    }
}

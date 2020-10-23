using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _NET_Core_Assessment.Models;
using _NET_Core_Assessment.Models.PostModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _NET_Core_Assessment.Controllers
{
    [Route("api/class")]
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

        [HttpPost("AddTeacher")]
        public IActionResult AddTeacher([FromBody]TeacherPostModel teacher)
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

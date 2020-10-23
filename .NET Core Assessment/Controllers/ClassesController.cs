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
    public class ClassesController : ControllerBase
    {

       [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ClassModel classModel)
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
            return Ok();
        }

        [HttpGet("GetAllStudentsFromClassRoomId")]
        public IActionResult GetAllStudentsFromClassRoomId(int classroomID)
        {
            return Ok();
        }
    }
}

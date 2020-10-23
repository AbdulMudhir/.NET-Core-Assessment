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
    public class ClassController : ControllerBase
    {
        private readonly List<ClassModel> _dummyData;
        private readonly ClassroomManager _classroomManager;

        public ClassController(ClassroomManager classroomManager)
        {
            _classroomManager = classroomManager;
            _dummyData = new List<ClassModel>() {
            new ClassModel() { ClassId = 1, ClassName= "ICT",School= "Hackney", Grade= "A+" },
            new ClassModel() { ClassId = 2, ClassName = "SCIENCE", School = "Hackney", Grade = "A+" },
            new ClassModel() { ClassId = 3, ClassName = "P.E", School = "Hackney", Grade = "A+" }

            };

        }


        [HttpPost("CreateClass")]
        public IActionResult CreateClass([FromBody] ClassPostModel classModel)
        {
            return Ok();
        }


        [HttpGet("GetAllClassRoomNames")]
        public async Task<IActionResult> GetAllClassRoomNames()
        {
            var data = await _classroomManager.GetClasses();

            return new JsonResult( data);
        }

    
    }
}

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
    public class StudentController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] StudentModel student)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetNamesAllStudentsFromClass()
        {
            return Ok();
        }

    }
}

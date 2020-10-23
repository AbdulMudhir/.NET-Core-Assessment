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
    public class TeacherController : ControllerBase
    {

        public IActionResult Create([FromBody] TeacherModel teacher)
        {
            return Ok();
        }

        public IActionResult AddClassRoom([FromBody] TeacherModel teacher)
        {
            return Ok();
        }
    }
}

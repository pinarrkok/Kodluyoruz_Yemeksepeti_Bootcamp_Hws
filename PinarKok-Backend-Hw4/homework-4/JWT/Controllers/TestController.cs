using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    public class TestController : ControllerBase
    {
        [HttpGet(Name = nameof(GetStudents))]
        public IActionResult GetStudents()
        {
            List<string> students = new List<string>()
            {
                "PinarKok",
                "PinarKok2"
            };

            return Ok(students);
        }

        [HttpGet(Name = nameof(GetStudents2))]
        public IActionResult GetStudents2()
        {
            List<string> students = new List<string>()
            {
                "Pinar",
                "Pinar2"
            };

            return Ok(students);
        }
    }
}

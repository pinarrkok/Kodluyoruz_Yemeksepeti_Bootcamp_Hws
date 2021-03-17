using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                WhiteList = new
                {
                    Ip = "::1",
                    Allows = new
                    {
                        CoursesController = "/api/courses",
                        RootController = "/api/root"
                    }
                },
                href = Url.Link(nameof(GetRoot), null),
                Albums = new
                {
                    href = Url.Link(nameof(CoursesController.GetCourses), null)
                },
                Songs = new
                {
                    href = Url.Link(nameof(ExamsController.GetExams), null)
                },
            };

            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhiteList.Attributes;
using WhiteList.Data.Context;
using WhiteList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteList.Data.Entities;

namespace WhiteList.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(IpControlAttribute))]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ExamDbContext _dbContext;
        public CoursesController(ExamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = nameof(GetCourses))]
        public IActionResult GetCourses()
        {

            List<Course> courses = _dbContext.Courses.ToList();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Course course = _dbContext.Courses.FirstOrDefault(course => course.Id == id);
            return Ok(course);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            _dbContext.Add(course);
            return Ok();
        }

    }
}

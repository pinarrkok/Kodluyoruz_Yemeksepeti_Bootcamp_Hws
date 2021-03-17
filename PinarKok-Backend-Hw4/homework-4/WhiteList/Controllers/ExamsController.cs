using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhiteList.Attributes;
using WhiteList.Data.Context;
using WhiteList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteList.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(IpControlAttribute))]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private ExamDbContext _dbContext;

        public ExamsController(ExamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = nameof(GetExams))]
        public IActionResult GetExams()
        {

            List<Exam> songs = _dbContext.Exams.ToList();
            return Ok(songs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Exam exam = _dbContext.Exams.FirstOrDefault(exam => exam.Id == id);
            return Ok(exam);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Exam exam)
        {
            _dbContext.Add(exam);
            return Ok();
        }
    }
}

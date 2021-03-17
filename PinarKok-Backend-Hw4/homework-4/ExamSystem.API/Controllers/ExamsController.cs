using ExamSystem.Entities;
using ExamSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            _examService.GetList();
            return StatusCode(200);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int examId)
        {
            _examService.GetById(examId);
            return StatusCode(200);
        }
    }
}

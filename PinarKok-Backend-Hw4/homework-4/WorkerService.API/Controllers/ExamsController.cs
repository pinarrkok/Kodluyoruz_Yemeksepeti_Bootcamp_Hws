using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkerService.Business.Abstract;
using WorkerService.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerService.API.Controllers
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

        [HttpGet("getbytitle")]
        public IActionResult GetByTitle(string examTitle)
        {
            _examService.GetByTitle(examTitle);
            return StatusCode(200);
        }

        [HttpPost("add")]
        public IActionResult Add(ExamDto examDto)
        {
            _examService.Add(examDto);
            return StatusCode(201);
        }

        [HttpPost("update")]
        public IActionResult Update(int examId)
        {
            _examService.Update(examId);
            return StatusCode(201);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int examId)
        {
            _examService.Delete(examId);
            return StatusCode(201);
        }
    }
}

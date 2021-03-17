using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkerService.Business.Abstract;
using WorkerService.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            _studentService.GetList();
            return StatusCode(200);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userId)
        {
            _studentService.GetById(userId);
            return StatusCode(200);
        }

        [HttpPost("add")]
        public IActionResult Add(Student student)
        {
            _studentService.Add(student);
            return StatusCode(201);
        }

        [HttpPost("update")]
        public IActionResult Update(Student student)
        {
            _studentService.Update(student);
            return StatusCode(201);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Student student)
        {
            _studentService.Delete(student);
            return StatusCode(201);
        }
    }
}

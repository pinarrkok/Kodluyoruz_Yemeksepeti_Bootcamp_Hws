using homework_2.Business;
using homework_2.Model;
using homework_2.Validation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController: ControllerBase
    {
        private IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public List<Exam> GetAll()
        {
            return _examService.GetAll();
        }

        [HttpPost("add")]
        [ValidationActionModel]
        public ActionResult Add([FromBody] ExamDto examDto)
        {
            var request = JsonConvert.DeserializeObject<ExamDto>(JsonConvert.SerializeObject(examDto));
            var context = new ValidationContext(request);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(request, context, validationResult, true);

            if (!isValid)
            {
                return BadRequest(validationResult);
            }

            _examService.Add(examDto);
            return StatusCode(201);
        }

        [HttpPost("remove")]
        public ActionResult Remove(int id)
        {
            _examService.Remove(id);
            return StatusCode(201);
        }

        [HttpPut("update")]
        [ValidationActionModel]
        public void Update([FromBody] ExamDto examDto)
        {
            _examService.Update(examDto);
        }
    }
}

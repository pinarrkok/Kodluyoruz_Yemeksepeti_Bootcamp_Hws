using JWT.Context;
using JWT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet(Name = nameof(GetExams))]
        public async Task<IActionResult> GetExams()
        {
            var exams = await _examService.GetExamsAsync();

            if (exams == null)
            {
                return NoContent();
            }
            return Ok(exams);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExaminationSystem.Business.Abstract;
using OnlineExaminationSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            _userService.GetList();
            return StatusCode(200);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userId)
        {
            _userService.GetById(userId);
            return StatusCode(200);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return StatusCode(201);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            _userService.Delete(user);
            return StatusCode(201);
        }
    }
}

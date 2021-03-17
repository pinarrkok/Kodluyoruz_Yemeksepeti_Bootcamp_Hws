﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    [Route("/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),
                Info = new
                {
                    href = Url.Link(nameof(InfoController.GetInfo), null)
                },
                rooms = new
                {
                    href = Url.Link(nameof(ExamsController.GetRooms), null)
                }
            };

            return Ok(response);
        }
    }
}

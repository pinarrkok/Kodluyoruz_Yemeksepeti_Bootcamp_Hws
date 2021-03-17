using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Versioning.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    public class TestController : ControllerBase
    {
        [HttpGet(Name = nameof(GetCustomers))]
        public IActionResult GetCustomers()
        {
            List<string> customers = new List<string>()
            {
                "PinarKok",
                "PinarKok2"
            };

            return Ok(customers);
        }

        [HttpGet(Name = nameof(GetCustomers2))]
        public IActionResult GetCustomers2()
        {
            List<string> customers = new List<string>()
            {
                "Pinar",
                "Pinar2"
            };

            return Ok(customers);
        }
    }
}

using JWT.Models.Derived;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly SystemInfo _systemInfo;

        public InfoController(IOptions<SystemInfo> systemInfoOption)
        {
            _systemInfo = systemInfoOption.Value;
        }

        [HttpGet(Name = nameof(GetInfo))]
        [ProducesResponseType(200)]
        public ActionResult<SystemInfo> GetInfo()
        {
            _systemInfo.Href = Url.Link(nameof(GetInfo), null);
            return _systemInfo;
        }
    }
}

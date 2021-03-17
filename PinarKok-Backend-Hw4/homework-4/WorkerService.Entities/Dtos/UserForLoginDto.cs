using WorkerService.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService.Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

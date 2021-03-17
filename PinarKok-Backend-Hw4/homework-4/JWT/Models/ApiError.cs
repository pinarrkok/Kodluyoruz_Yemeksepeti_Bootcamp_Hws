﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class ApiError
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public ApiVersion Version { get; set; }
    }
}

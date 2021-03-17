using JWT.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Filters
{
    public class JsonExceptionFilters : IExceptionFilter
    {
        private readonly IWebHostEnvironment _environment;

        public JsonExceptionFilters(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public void OnException(ExceptionContext context)
        {
            var isDevelopment = _environment.IsDevelopment();

            var error = new ApiError
            {
                Version = context.HttpContext.GetRequestedApiVersion(),
                Message = isDevelopment ? context.Exception.Message : "Api Error",
                Detail = isDevelopment ? context.Exception.StackTrace : context.Exception.Message
            };

            context.Result = new ObjectResult(error) { StatusCode = 500 };
        }
    }
}

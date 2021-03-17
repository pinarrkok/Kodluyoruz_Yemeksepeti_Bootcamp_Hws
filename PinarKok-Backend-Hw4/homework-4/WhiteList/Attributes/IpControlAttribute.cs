﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WhiteList.Data.Entities;

namespace WhiteList.Attributes
{
    public class IpControlAttribute : ActionFilterAttribute
    {
        IConfiguration _configuration;
        private List<WhiteListDto> _whiteLists;

        public IpControlAttribute(IConfiguration configuration, IOptions<List<WhiteListDto>> whiteLists)
        {
            _configuration = configuration;
            _whiteLists = whiteLists.Value;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IPAddress remoteIp = context.HttpContext.Connection.RemoteIpAddress;
            string apiPath = context.HttpContext.Request.Path;

            var whiteListItem = _whiteLists.FirstOrDefault(wh => IPAddress.Parse(wh.Ip).Equals(remoteIp));

            string checkAllow = whiteListItem.Allows.FirstOrDefault(allow => allow.Equals(apiPath));

            if (string.IsNullOrEmpty(checkAllow))
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}

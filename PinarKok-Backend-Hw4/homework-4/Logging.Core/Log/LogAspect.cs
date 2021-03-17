using Logging.Core.Log.Log4Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Core.Log
{
    public class LogAspect
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new Exception("Yanlış logger service.!.!...");
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }
    }
}

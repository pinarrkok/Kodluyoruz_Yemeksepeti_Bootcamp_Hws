using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Core.Log.Log4Net.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger(): base("JsonFileLogger")
        {
        }
    }
}

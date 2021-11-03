using QueryHandler.Interfaces;
using Serilog;
using Serilog.Filters;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryHandler.Logging
{
    internal class Logger
    {
        public static ILogger Create()
        {
            return new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();
        }
    }
}
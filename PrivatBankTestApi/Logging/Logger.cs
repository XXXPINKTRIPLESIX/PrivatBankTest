using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PrivatBankTestApi.Logging
{
    // public class Logger
    // {
    //     private readonly ILogger<Logger> _logger;
    //     public Logger(ILogger<Logger> logger)
    //     {
    //         _logger = logger;
    //     }
    //     
    //     public static ILogger Create()
    //     {
    //         return new LoggerConfiguration()
    //                         .WriteTo.Console()
    //                         .Enrich.WithClientIp()
    //                         .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
    //                         .CreateLogger();
    //     }
    //
    //     public static void LogException(Exception e)
    //     {
    //         Log.Logger
    //             .ForContext("log", "EXCEPTION")
    //             .Error("Error: {error_message}\nStack trace: {stack_trace}",
    //                 e.Message,
    //                 e.StackTrace);
    //     }
    //}
}

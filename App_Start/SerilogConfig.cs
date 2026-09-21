using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.App_Start
{
    public static class SerilogConfig
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    new JsonFormatter(),
                    "logs/app-.json",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    shared: true)
                .CreateLogger();
        }
    }
}
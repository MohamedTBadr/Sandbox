using Serilog;
using Serilog.Formatting.Json;
using System.Web.Hosting;

namespace Sandbox.App_Start
{
    public static class SerilogConfig
    {
        public static void Configure()
        {
            var logPath = HostingEnvironment.MapPath("~/logs/app-.json");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    new JsonFormatter(),
                    logPath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    shared: true)
                .CreateLogger();
        }
    }
}
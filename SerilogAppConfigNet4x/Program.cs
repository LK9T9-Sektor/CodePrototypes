using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace SerilogAppConfigNet4x
{
    class Program
    {
        static void Main(string[] args)
        {
            // Getting the execution directory your executable is running in, even if it is run by Windows Task Scheduler
            // environment variables are per-process (inherited from their parent process)
            Environment.SetEnvironmentVariable("BASEDIR", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();

            Log.Information("App start");

            Log.Information("App end");
        }
    }
}

using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace SerilogM.E.C
{
    class Program
    {
        static void Main(string[] args)
        {
            var basedir = "BASEDIR";
            Environment.SetEnvironmentVariable(basedir, Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            var basePath = Environment.GetEnvironmentVariable(basedir);

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false, true);

            var configuration = configurationBuilder.Build();

            ILogger log = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            log.Information("App start");

            log.Information("App end");
        }
    }
}

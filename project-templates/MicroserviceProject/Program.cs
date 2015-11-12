using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MicroserviceProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureSerilog();
            HostFactory.Run(x => 
            {
                x.Service<Service>();
                x.UseSerilog();
            });
        }

        private static void ConfigureSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .WriteTo.RollingFile(@"logs\$safeprojectname$-{Date}.txt")
                .CreateLogger()
                .ForContext("ApplicationName", "");
        }
    }
}

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace StayGreen.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            const string STAYGREEN_ENVIRONMENT_KEY = "STAYGREEN_ENVIRONMENT";

            var environment = Environment.GetEnvironmentVariable(STAYGREEN_ENVIRONMENT_KEY, EnvironmentVariableTarget.User);

            if (environment == null)
            {
                environment = Environment.GetEnvironmentVariable(STAYGREEN_ENVIRONMENT_KEY, EnvironmentVariableTarget.Machine);
            }

            environment = environment ?? "Development";

            Debug.WriteLine(environment);
            Console.WriteLine(environment);

            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hosting, config) =>
                {
                    config.AddJsonFile($"appsettings.{environment}.json", optional: true);
                    config.AddEnvironmentVariables("STAYGREEN_");
                    config.AddCommandLine(args);
                })
                .UseEnvironment(environment)
                    .UseStartup<Startup>()
                    .Build();
        }
    }
}

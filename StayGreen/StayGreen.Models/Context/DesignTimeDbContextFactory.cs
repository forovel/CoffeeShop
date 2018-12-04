using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace StayGreen.Models.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        const string STAYGREEN_ENVIRONMENT_KEY = "STAYGREEN_ENVIRONMENT";

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var appSettingsPath = args.Length != 0 && !string.IsNullOrWhiteSpace(args[0])
                ? args[0]
                : Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "StayGreen.Web");

            Console.WriteLine($"APP SETTINGS: {appSettingsPath}");

            var environment = Environment.GetEnvironmentVariable(STAYGREEN_ENVIRONMENT_KEY, EnvironmentVariableTarget.User);

            if (environment == null)
            {
                environment = Environment.GetEnvironmentVariable(STAYGREEN_ENVIRONMENT_KEY, EnvironmentVariableTarget.Machine);
            }

            Console.WriteLine($"STAYGREEN Environment: {environment}");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(appSettingsPath)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("Default");

            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}

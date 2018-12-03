using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayGreen.Common.Settings;
using StayGreen.Models;

namespace StayGreen.Configuration
{
    public static class ApplicationSettings
    {
        public static void ConfigureApplicationSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            services.AddTransient<Seeder>();
        }
    }
}

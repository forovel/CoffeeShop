using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayGreen.Common.Settings;
using StayGreen.Models;
using StayGreen.Services.Interfaces;
using StayGreen.Web.Common;

namespace StayGreen.Configuration
{
    public static class ApplicationSettings
    {
        public static void ConfigureApplicationSettings(IServiceCollection services, IConfiguration configuration)
        {
            //User claims
            services.AddScoped<IUserWrapper, UserWrapper>();

            //Configurations from appsettings.json
            services.Configure<AppSettings>(configuration);
            services.AddSingleton(configuration);

            //Seeder for default data
            services.AddTransient<Seeder>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}

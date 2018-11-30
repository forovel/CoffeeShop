using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayGreen.Models.Context;

namespace StayGreen.Configuration
{
    public static class ConnectionSettings
    {
        public static void ConfigureConnectionSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        }
    }
}

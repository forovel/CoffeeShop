using Microsoft.Extensions.DependencyInjection;
using StayGreen.Services;
using StayGreen.Services.Interfaces;

namespace StayGreen.Configuration
{
    public static class WebApi
    {
        public static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}

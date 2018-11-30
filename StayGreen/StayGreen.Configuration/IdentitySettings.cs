using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StayGreen.Models.Context;
using StayGreen.Models.Schema;

namespace StayGreen.Configuration
{
    public static class IdentitySettings
    {
        public static void ConfigureIdentitySettings(IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders()
                    .AddUserManager<UserManager<User>>();

            services.Configure<IdentityOptions>(optrions => 
            {
                optrions.SignIn.RequireConfirmedEmail = false;
            });
        }
    }
}

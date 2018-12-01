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

            services.Configure<IdentityOptions>(options => 
            {
                //Sing in settings
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                //Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
        }
    }
}

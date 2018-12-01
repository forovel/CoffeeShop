using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayGreen.Configuration;
using StayGreen.Models;
using System;

namespace StayGreen.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Configure connections
            ConnectionSettings.ConfigureConnectionSettings(services, Configuration);

            //Configure Identity Settings
            IdentitySettings.ConfigureIdentitySettings(services);

            //Register Dependencies of services
            WebApi.ConfigureDependencyInjection(services);

            services.AddTransient<Seeder>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/AdminLoco/Login";
                options.LogoutPath = $"/AdminLoco/Logout";
                options.AccessDeniedPath = $"/AdminLoco/AccessDenied";
                options.Cookie.Name = "stay_green_cookie";
                options.Cookie.HttpOnly = true;
                //
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //Creates new cookie pre request
                options.SlidingExpiration = true;

                options.Cookie.Expiration = TimeSpan.FromDays(14);
            });

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.AllowAreas = true;
                options.Conventions.AuthorizeAreaPage("AdminLoco", "/Logout");

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //Add default data to first migration
            seeder.Seed().Wait();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}

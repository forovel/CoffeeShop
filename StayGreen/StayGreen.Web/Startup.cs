using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayGreen.Configuration;
using StayGreen.Models;
using StayGreen.Web.Common.Helpers;
using StayGreen.Web.Common.Middlewares;
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

            //Application settings such as default seeder, sttings from json file, ext.
            ApplicationSettings.ConfigureApplicationSettings(services, Configuration);

            //Add auto mapper configuration
            MappingProfile.InitMappingProfile();

            //Add fluent validation rules and settings
            FluentValidationSettings.CofidureFluentValidationDependencyInjection(services);

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

            services.AddSingleton<MvcResponse>();

            services.AddMvc().AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaPage("AdminLoco", "/Logout");
                })
                //.AddFluentValidation()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                //app.UseStayGreenMvcExceptionHandler();
                //app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseStayGreenMvcExceptionHandler();
            app.UseHsts();

            app.UseAuthentication();

            //Add default data to first migration
            //seeder.Seed().Wait();

            //app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");

            app.UseMvc();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayGreen.Common.Constatns;
using StayGreen.Models.Context;
using StayGreen.Models.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebStartup = StayGreen.Web.Startup;

namespace StayGreen.Tools
{
    class Program
    {
        /// <summary>
        /// Creates superadmin with all roles.
        /// </summary>
        /// <param name="args">
        /// args[0] - Command name,
        /// args[1] - Email,
        /// args[2] - First name,
        /// args[3] - Last name
        /// </param>
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            if (args[0] == "create-superadmin" || args[0] == "create-admin")
            {
                if (args.Length == 4
                    && args[0] == "create-superadmin"
                    && !string.IsNullOrWhiteSpace(args[1])
                    && !string.IsNullOrWhiteSpace(args[2])
                    && !string.IsNullOrWhiteSpace(args[3]))
                {
                    CreateSuperadmin(args[1], args[2], args[3]);
                }
                else if (args.Length == 4
                    && args[0] == "create-admin"
                    && !string.IsNullOrWhiteSpace(args[1])
                    && !string.IsNullOrWhiteSpace(args[2])
                    && !string.IsNullOrWhiteSpace(args[3]))
                {
                    CreateAdmin(args[1], args[2], args[3]);
                }
                else
                {
                    Console.WriteLine("Incorrect arguments, try again");
                }

            }

            Console.ReadLine();
        }


        private static void CreateSuperadmin(string email, string firstName, string lastName)
        {
            Console.WriteLine("Creating super admin...");

            var currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var appSettingsPath = Path.Combine(currentDirectory.Substring(0, currentDirectory.IndexOf("StayGreen") + 6), "StayGreen.Web");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(appSettingsPath)
                .AddJsonFile($"appsettings.json", optional: true)
                .Build();

            var serviceCollection = new ServiceCollection();
            var startup = new WebStartup(configuration);
            startup.ConfigureServices(serviceCollection);
            var provider = serviceCollection.BuildServiceProvider();

            using (var context = new DesignTimeDbContextFactory().CreateDbContext(new[] { appSettingsPath }))
            {
                var userManager = provider.GetRequiredService<UserManager<User>>();

                if (!context.Roles.Any())
                {
                    var roles = new List<Role>
                    {
                        new Role
                        {
                            Id = Roles.Superadmin,
                            Name = StringRoles.Superadmin
                        },
                        new Role
                        {
                            Id = Roles.Admin,
                            Name = StringRoles.Admin
                        },
                        new Role
                        {
                            Id = Roles.Client,
                            Name = StringRoles.Client
                        }
                    };
                    context.AddRange(roles);
                    context.SaveChanges();
                }

                var existedUser = context.Users.SingleOrDefault(u => u.Email == email);
                User superadmin;
                if (existedUser == null)
                {
                    string password = "Superadmin1234!";

                    superadmin = new User
                    {
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        UserName = email
                    };
                    //TODO: check if user created
                    userManager.CreateAsync(superadmin, password).Wait();
                }
                else
                {
                    superadmin = existedUser;
                    var oldRoles = context.UserRoles.Where(ur => ur.UserId == superadmin.Id);
                    context.UserRoles.RemoveRange(oldRoles);
                    context.SaveChanges();
                }

                #region Assigning Roles

                var superadminRole = context.Roles.FirstOrDefault(x => x.Name == StringRoles.Superadmin);
                var adminRole = context.Roles.FirstOrDefault(x => x.Name == StringRoles.Admin);
                var clienRole = context.Roles.FirstOrDefault(x => x.Name == StringRoles.Client);

                var userRoles = new List<UserRole>
                {
                    new UserRole
                    {
                        RoleId = superadminRole.Id,
                        UserId = superadmin.Id
                    },
                    new UserRole
                    {
                        RoleId = adminRole.Id,
                        UserId = superadmin.Id
                    },
                    new UserRole
                    {
                        RoleId = clienRole.Id,
                        UserId = superadmin.Id
                    }
                };
                context.AddRange(userRoles);
                context.SaveChanges();

                #endregion
            }

            Console.WriteLine("Created!");
        }

        private static void CreateAdmin(string email, string firstName, string lastName)
        {
            Console.WriteLine("Creating admin...");

            var currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var appSettingsPath = Path.Combine(currentDirectory.Substring(0, currentDirectory.IndexOf("StayGreen") + 6), "StayGreen.Web");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(appSettingsPath)
                .AddJsonFile($"appsettings.json", optional: true)
                .Build();

            var serviceCollection = new ServiceCollection();
            var startup = new WebStartup(configuration);
            startup.ConfigureServices(serviceCollection);
            var provider = serviceCollection.BuildServiceProvider();

            using (var context = new DesignTimeDbContextFactory().CreateDbContext(new[] { appSettingsPath }))
            {
                var userManager = provider.GetRequiredService<UserManager<User>>();

                if (!context.Roles.Any())
                {
                    var roles = new List<Role>
                    {
                        new Role
                        {
                            Id = Roles.Superadmin,
                            Name = StringRoles.Superadmin
                        },
                        new Role
                        {
                            Id = Roles.Admin,
                            Name = StringRoles.Admin
                        },
                        new Role
                        {
                            Id = Roles.Client,
                            Name = StringRoles.Client
                        }
                    };
                    context.AddRange(roles);
                    context.SaveChanges();
                }

                var existedUser = context.Users.SingleOrDefault(u => u.Email == email);
                User admin;
                if (existedUser == null)
                {
                    string password = "Admin1234!";

                    admin = new User
                    {
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        UserName = email
                    };
                    //TODO: check if user created
                    userManager.CreateAsync(admin, password).Wait();
                }
                else
                {
                    admin = existedUser;
                    var oldRoles = context.UserRoles.Where(ur => ur.UserId == admin.Id);
                    context.UserRoles.RemoveRange(oldRoles);
                    context.SaveChanges();
                }

                #region Assigning Roles

                var adminRole = context.Roles.FirstOrDefault(x => x.Name == StringRoles.Admin);
                var clienRole = context.Roles.FirstOrDefault(x => x.Name == StringRoles.Client);

                var userRoles = new List<UserRole>
                {
                    new UserRole
                    {
                        RoleId = adminRole.Id,
                        UserId = admin.Id
                    },
                    new UserRole
                    {
                        RoleId = clienRole.Id,
                        UserId = admin.Id
                    }
                };
                context.AddRange(userRoles);
                context.SaveChanges();

                #endregion
            }

            Console.WriteLine("Created!");
        }
    }
}

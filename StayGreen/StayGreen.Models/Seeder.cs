using Microsoft.AspNetCore.Identity;
using StayGreen.Common.Constatns;
using StayGreen.Models.Context;
using StayGreen.Models.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StayGreen.Models
{
    public class Seeder
    {
        readonly ApplicationDbContext _context;
        readonly UserManager<User> _manager;

        public Seeder(
            ApplicationDbContext context,
            UserManager<User> manager
            )
        {
            _context = context;
            _manager = manager;
        }

        //List<Technology> GetDefaultTechnologies()
        //{
        //    var result = new List<Technology>
        //    {
        //        new Technology { Name = "React" },
        //        new Technology { Name = ".NET" },
        //        new Technology { Name = "NodeJS" },
        //        new Technology { Name = "iOS" },
        //        new Technology { Name = "Android" },
        //    };

        //    return result;

        //}

        //List<ForeignLanguage> GetDefaultForeignLanguages()
        //{
        //    var result = new List<ForeignLanguage>
        //    {
        //        new ForeignLanguage { Name = "English" },
        //        new ForeignLanguage { Name = "Deutsch" }
        //    };

        //    return result;
        //}

        public async Task Seed()
        {
            Console.WriteLine("Seeding...");

            if (!_context.Roles.Any())
            {
                var roles = new List<Role> {
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

                await _context.AddRangeAsync(roles);
                await _context.SaveChangesAsync();
            }

            if (!_context.Users.Any())
            {
                var superAdmin = new User
                {
                    UserName = "LocoAdmin",
                    Email = "work@bizico.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    PhoneNumber = "+380000006",
                };

                var result = await _manager.CreateAsync(superAdmin, "Superadmin1234!");
                //await _context.SaveChangesAsync();

                var createdSuperadmin = _context.Users.FirstOrDefault();

                //_context.Users.Add(superAdmin);
                // _context.SaveChanges();

                var superadminRole = _context.Roles.FirstOrDefault(x => x.Name == StringRoles.Superadmin);
                var adminRole = _context.Roles.FirstOrDefault(x => x.Name == StringRoles.Admin);
                var clientRole = _context.Roles.FirstOrDefault(x => x.Name == StringRoles.Client);

                var userRoles = new List<UserRole>
                {
                    new UserRole
                    {
                        RoleId = superadminRole.Id,
                        UserId = createdSuperadmin.Id
                    },
                    new UserRole
                    {
                        RoleId = adminRole.Id,
                        UserId = createdSuperadmin.Id
                    },
                    new UserRole
                    {
                        RoleId = clientRole.Id,
                        UserId = createdSuperadmin.Id
                    }
                };

                await _context.AddRangeAsync(userRoles);
                await _context.SaveChangesAsync();
            }
        }
    }
}

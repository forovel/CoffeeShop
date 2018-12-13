using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StayGreen.Models.ConfigurationSchema;
using StayGreen.Models.Schema;
using System;

namespace StayGreen.Models.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AttachmentGroup> AttachmentGroups { get; set; }
        public DbSet<Coffee> Coffee { get; set; }
        public DbSet<CoffeePreparation> CoffeePreparations { get; set; }
        public DbSet<CoffeePrise> CoffeePrises { get; set; }
        public DbSet<OrderedCoffee> OrderedCoffee { get; set; }
        public DbSet<Order> Orders { get; set; }
        //Many to many tables
        public DbSet<AttachmentCoffee> AttachmentsCoffee { get; set; }
        public DbSet<CoffeePreparationCoffee> CoffeePreparationsCoffee { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new UserClaimConfiguration());
            builder.ApplyConfiguration(new UserLoginConfiguration());
            builder.ApplyConfiguration(new UserTokenConfiguration());
            builder.ApplyConfiguration(new AttachmentConfiguration());
            builder.ApplyConfiguration(new AttachmentGroupConfiguration());
            builder.ApplyConfiguration(new CoffeeConfiguration());
            builder.ApplyConfiguration(new CoffeePreparationConfiguration());
            builder.ApplyConfiguration(new CoffeePriseConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderedCoffeeConfiguration());
            //Many to many tables
            builder.ApplyConfiguration(new AttachmentCoffeeConfiguration());
            builder.ApplyConfiguration(new CoffeePreparationCoffeeConfiguration());
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //Table name
            builder.ToTable("Roles");

            //Key defining
            builder.HasKey(x => x.Id);

            //Properties
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(256)").IsRequired(true);

            //Constratints
            builder.HasIndex(x => x.Name).HasName("Index_RoleName").IsUnique();

            //Reverse navigation
            builder.HasMany(x => x.RoleClaims).WithOne(r => r.Role);

            //Ignore properties
            builder.Ignore(x => x.IsDeleted);
            builder.Ignore(x => x.DateCreated);
            builder.Ignore(x => x.DateUpdated);
            builder.Ignore(x => x.CreatedById);
            builder.Ignore(x => x.UpdatedById);

        }
    }
}

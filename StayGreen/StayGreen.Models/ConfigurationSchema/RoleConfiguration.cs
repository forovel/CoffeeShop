using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //Key defining
            builder.HasKey(x => x.Id);

            //Properties
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar").HasMaxLength(250);

            //Constratints
            builder.HasIndex(u => u.Name).HasName("Index_Name").IsUnique();

            //Ignore properties
            builder.Ignore(x => x.IsDeleted);
            builder.Ignore(x => x.DateCreated);
            builder.Ignore(x => x.DateUpdated);
            builder.Ignore(x => x.CreatedById);
            builder.Ignore(x => x.UpdatedById);

        }
    }
}

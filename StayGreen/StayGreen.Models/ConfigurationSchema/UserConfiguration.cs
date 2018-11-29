using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Key defining
            builder.HasKey(x => x.Id);

            //Properties
            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("varchar").HasMaxLength(250);
            builder.Property(x => x.LastName).HasColumnName(@"FirstName").HasColumnType("varchar").HasMaxLength(250);

            //Constratints
            builder.HasIndex(u => u.Email).HasName("Index_Email").IsUnique();

            //Ignore properties
            builder.Ignore(x => x.DateCreated);
            builder.Ignore(x => x.DateUpdated);
            builder.Ignore(x => x.CreatedById);
            builder.Ignore(x => x.UpdatedById);
        }
    }
}

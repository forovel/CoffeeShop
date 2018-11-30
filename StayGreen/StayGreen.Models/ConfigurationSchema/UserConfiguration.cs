using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Table name
            builder.ToTable("Users");

            //Key defining
            builder.HasKey(x => x.Id);

            //Properties
            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("nvarchar(256)").IsRequired(true);
            builder.Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("nvarchar(256)").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired(true).HasDefaultValue(false);

            //Constratints
            builder.HasIndex(u => u.Email).HasName("Index_Email").IsUnique();

            //Reverse navigation
            builder.HasMany(u => u.UserLogins).WithOne(u => u.User);
            builder.HasMany(u => u.UserTokens).WithOne(u => u.User);
            builder.HasMany(u => u.UserClaims).WithOne(u => u.User);

            //Ignore properties
            builder.Ignore(x => x.DateCreated);
            builder.Ignore(x => x.DateUpdated);
            builder.Ignore(x => x.CreatedById);
            builder.Ignore(x => x.UpdatedById);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            //Table name
            builder.ToTable("UserTokens");

            //Foreign keys
            builder.HasOne(ut => ut.User).WithMany(ut => ut.UserTokens).HasForeignKey(ut => ut.UserId);
        }
    }
}

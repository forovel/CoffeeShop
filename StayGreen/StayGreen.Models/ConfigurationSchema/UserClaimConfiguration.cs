using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            //Table name
            builder.ToTable("UserClaims");

            //Foreign keys
            builder.HasOne(ut => ut.User).WithMany(ut => ut.UserClaims).HasForeignKey(ut => ut.UserId);
        }
    }
}

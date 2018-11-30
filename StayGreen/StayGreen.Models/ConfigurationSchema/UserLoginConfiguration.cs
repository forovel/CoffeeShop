using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            //Table name
            builder.ToTable("UserLogins");

            //Foreign keys
            builder.HasOne(ul => ul.User).WithMany(ul => ul.UserLogins).HasForeignKey(ul => ul.UserId);
        }
    }
}

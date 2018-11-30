using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            //Table name
            builder.ToTable("RoleClaims");

            //Foreign keys
            builder.HasOne(rc => rc.Role).WithMany(rc => rc.RoleClaims).HasForeignKey(rc => rc.RoleId);
        }
    }
}

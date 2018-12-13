using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.ConfigurationSchema.Common;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class OrderConfiguration : EntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("Orders");

            builder.Property(x => x.TotalAmount).HasColumnName("TotalAmount").HasColumnType("int").IsRequired(true);
            builder.Property(x => x.TotalPrice).HasColumnName("TotalPrice").HasColumnType("float(53)").IsRequired(true);
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar(512)").IsRequired(true);
            builder.Property(x => x.LastName).HasColumnName("LastName").HasColumnType("nvarchar(512)").IsRequired(true);
            builder.Property(x => x.PostCode).HasColumnName("PostCode").HasColumnType("varchar(15)").IsRequired(true);
            builder.Property(x => x.Address).HasColumnName("Address").HasColumnType("nvarchar(512)").IsRequired(true);
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar(256)").IsRequired(true);
            builder.Property(x => x.OrderStatus).HasColumnName("OrderStatus").HasColumnType("int").ValueGeneratedOnAdd().IsRequired(true);

            //Reverse navigation
            builder.HasMany(x => x.OrderedCoffee).WithOne(x => x.Order).HasForeignKey(x => x.CoffeeId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}

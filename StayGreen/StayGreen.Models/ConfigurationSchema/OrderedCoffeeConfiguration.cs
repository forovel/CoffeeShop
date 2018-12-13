using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.ConfigurationSchema.Common;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class OrderedCoffeeConfiguration : EntityConfiguration<OrderedCoffee>
    {
        public override void Configure(EntityTypeBuilder<OrderedCoffee> builder)
        {
            base.Configure(builder);

            //Table name
            builder.ToTable("OrderedCoffee");

            builder.Property(x => x.Amount).HasColumnName("Amount").HasColumnType("int").IsRequired(true);
            builder.Property(x => x.CoffeePrise).HasColumnName("CoffeePrise").HasColumnType("float(53)").IsRequired(true);
            builder.Property(x => x.CoffeeWeight).HasColumnName("CoffeeWeight").HasColumnType("int").IsRequired(true);
            builder.Property(x => x.CoffeeRoasting).HasColumnName("CoffeeRoasting").HasColumnType("int").IsRequired(true);

            //Foreign keys
            builder.HasOne(x => x.Order).WithMany(x => x.OrderedCoffee).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Coffee).WithMany(x => x.OrderedCoffee).HasForeignKey(x => x.CoffeeId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.Attachment).WithMany(x => x.OrderedCoffee).HasForeignKey(x => x.AttachmentId).OnDelete(DeleteBehavior.SetNull);


        }
    }
}

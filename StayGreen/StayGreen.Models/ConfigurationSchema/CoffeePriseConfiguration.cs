using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.ConfigurationSchema.Common;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class CoffeePriseConfiguration : EntityConfiguration<CoffeePrise>
    {
        public override void Configure(EntityTypeBuilder<CoffeePrise> builder)
        {
            base.Configure(builder);

            //Table name
            builder.ToTable("CoffeePrises");

            //Properties
            builder.Property(x => x.CoffeeWeight).HasColumnName("CoffeeWeight").HasColumnType("int").IsRequired(true);
            builder.Property(x => x.Prise).HasColumnName("Prise").HasColumnType("float(53)").HasDefaultValue(0).IsRequired(true);

            //Foreign keys
            builder.HasOne(x => x.Coffee).WithMany(x => x.CoffeePrises).HasForeignKey(x => x.CoffeeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

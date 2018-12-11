using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class CoffeePreparationCoffeeConfiguration : IEntityTypeConfiguration<CoffeePreparationCoffee>
    {
        public void Configure(EntityTypeBuilder<CoffeePreparationCoffee> builder)
        {
            builder.ToTable("CoffeePreparationsCoffee");

            builder.HasKey(x => new { x.CoffeeId, x.CoffeePreparationId });

            builder.HasOne(x => x.Coffee).WithMany(x => x.CoffeePreparationCoffee).HasForeignKey(x => x.CoffeeId);
            builder.HasOne(x => x.CoffeePreparation).WithMany(x => x.CoffeePreparationCoffee).HasForeignKey(x => x.CoffeePreparationId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.ConfigurationSchema.Common;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class CoffeeConfiguration : NamedEntityConfiguration<Coffee>
    {
        public override void Configure(EntityTypeBuilder<Coffee> builder)
        {
            base.Configure(builder);

            //Table name
            builder.ToTable("Coffee");

            //Properties
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar(4000)").IsRequired(false);
            builder.Property(x => x.Sour).HasColumnName("Sour").HasColumnType("int").HasDefaultValue(0).IsRequired(true);
            builder.Property(x => x.Saturation).HasColumnName("Saturation").HasColumnType("int").HasDefaultValue(0).IsRequired(true);
            builder.Property(x => x.Bitterness).HasColumnName("Bitterness").HasColumnType("int").HasDefaultValue(0).IsRequired(true);
            builder.Property(x => x.Fortress).HasColumnName("Fortress").HasColumnType("int").HasDefaultValue(0).IsRequired(true);
            builder.Property(x => x.Category).HasColumnName("Category").HasColumnType("int").IsRequired(true);
            builder.Property(x => x.CoffeeCategory).HasColumnName("CoffeeCategory").HasColumnType("int").IsRequired(true);
            builder.Property(x => x.CoffeeRegion).HasColumnName("CoffeeRegion").HasColumnType("int").IsRequired(true);

            //Reverse navigation
            builder.HasMany(x => x.CoffeePrises).WithOne(x => x.Coffee).HasForeignKey(x => x.CoffeeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.OrderedCoffee).WithOne(x => x.Coffee).HasForeignKey(x => x.CoffeeId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(x => x.CoffeePreparationCoffee).WithOne(x => x.Coffee).HasForeignKey(x => x.CoffeeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.AttachmentsCoffee).WithOne(x => x.Coffee).HasForeignKey(x => x.CoffeeId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}

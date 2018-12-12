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
            builder.Property(x => x.Rating).HasColumnName("Rating").HasColumnType("float(53)").IsRequired(true);
            builder.Property(x => x.Composition).HasColumnName("Composition").HasColumnType("nvarchar(512)").IsRequired(true);
            builder.Property(x => x.Sour).HasColumnName("Sour").HasColumnType("int").HasDefaultValue(0).IsRequired(true);
            builder.Property(x => x.Saturation).HasColumnName("Saturation").HasColumnType("int").HasDefaultValue(0).IsRequired(true);
            builder.Property(x => x.Bitterness).HasColumnName("Bitterness").HasColumnType("int").HasDefaultValue(0).IsRequired(true);
            builder.Property(x => x.Fortress).HasColumnName("Fortress").HasColumnType("int").HasDefaultValue(0).IsRequired(true);

            //Foreign Keys
            builder.HasOne(x => x.CoffeeCategory).WithMany(x => x.Coffee).HasForeignKey(x => x.CoffeeCategoryId);
            builder.HasOne(x => x.CoffeeRegion).WithMany(x => x.Coffee).HasForeignKey(x => x.CoffeeRegionId);
            builder.HasOne(x => x.Category).WithMany(x => x.Coffee).HasForeignKey(x => x.CoffeeCategoryId);

            //Reverse navigation
            //builder.HasMany(x => x.At)

        }
    }
}

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
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType(@"nvarchar(4000)").IsRequired(false);
            builder.Property(x => x.Rating).HasColumnName(@"Rating").HasColumnType(@"float(53)").IsRequired(true);

            //Reverse navigation
            builder.HasMany(x => x.Orders).WithOne(x => x.C);
        }
    }
}

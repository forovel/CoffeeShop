using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.ConfigurationSchema.Common;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class CoffeeCategoryConfiguration : NamedEntityConfiguration<CoffeeCategory>
    {
        public override void Configure(EntityTypeBuilder<CoffeeCategory> builder)
        {
            base.Configure(builder);

            //Reverse navigation
            builder.HasMany(x => x.Coffee).WithOne(x => x.CoffeeCategory).HasForeignKey(x => x.CoffeeCategoryId);
        }
    }
}

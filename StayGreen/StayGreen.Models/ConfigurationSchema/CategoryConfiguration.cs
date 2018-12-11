using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.ConfigurationSchema.Common;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class CategoryConfiguration : NamedEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            //Reverse navigation
            builder.HasMany(x => x.Coffee).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}

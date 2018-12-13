using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.ConfigurationSchema.Common;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class CoffeePreparationConfiguration : NamedEntityConfiguration<CoffeePreparation>
    {
        public override void Configure(EntityTypeBuilder<CoffeePreparation> builder)
        {
            base.Configure(builder);

            //Table name
            builder.ToTable("CoffeePreparations");

            //Foreign keys
            builder.HasOne(x => x.Attachment).WithMany(x => x.CoffeePreparations).HasForeignKey(x => x.AttachmentId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}

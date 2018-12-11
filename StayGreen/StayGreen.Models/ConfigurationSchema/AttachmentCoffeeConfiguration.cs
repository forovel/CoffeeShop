using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class AttachmentCoffeeConfiguration : IEntityTypeConfiguration<AttachmentCoffee>
    {
        public void Configure(EntityTypeBuilder<AttachmentCoffee> builder)
        {
            builder.ToTable("AttachmentsCoffee");

            builder.HasKey(x => new { x.AttachmentId, x.CoffeeId });

            builder.HasOne(x => x.Attachment).WithMany(x => x.AttachmentsCoffee).HasForeignKey(x => x.AttachmentId);
            builder.HasOne(x => x.Coffee).WithMany(x => x.AttachmentsCoffee).HasForeignKey(x => x.CoffeeId);
        } 
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.ConfigurationSchema.Common;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class AttachmentGroupConfiguration : NamedEntityConfiguration<AttachmentGroup>
    {
        public override void Configure(EntityTypeBuilder<AttachmentGroup> builder)
        {
            base.Configure(builder);

            //Table name
            builder.ToTable("AttachmentGroups");

            //Properties
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType(@"nvarchar(512)").IsRequired(false);

            //Reverse navigation
            builder.HasMany(x => x.Attachments).WithOne(x => x.AttachmentGroup);
        }
    }
}

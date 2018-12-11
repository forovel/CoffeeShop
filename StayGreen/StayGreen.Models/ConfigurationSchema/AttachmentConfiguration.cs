using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.ConfigurationSchema.Common;
using StayGreen.Models.Schema;

namespace StayGreen.Models.ConfigurationSchema
{
    public class AttachmentConfiguration : NamedEntityConfiguration<Attachment>
    {
        public override void Configure(EntityTypeBuilder<Attachment> builder)
        {
            base.Configure(builder);

            //Table name
            builder.ToTable("Attachments");

            //Properties
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar(512)").IsRequired(false);
            builder.Property(x => x.Path).HasColumnName("Path").HasColumnType("varchar(4000)").IsRequired(true);

            //Reverse navigation
            builder.HasOne(x => x.AttachmentGroup).WithMany(x => x.Attachments).HasForeignKey(x => x.AttachmentGroupId);
        }
    }
}

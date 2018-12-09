using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema.Common;
using System;

namespace StayGreen.Models.ConfigurationSchema.Common
{
    public abstract class NamedEntityConfiguration<T> : EntityConfiguration<T> where T : NamedEntity<Guid>
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(512)").IsRequired(true);
        }
    }
}

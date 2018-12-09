using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayGreen.Models.Schema.Common;
using System;

namespace StayGreen.Models.ConfigurationSchema.Common
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity<Guid>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted").HasColumnType("bit").HasDefaultValue(false).IsRequired(true);
            builder.Property(x => x.DateCreated).HasColumnName("DateCreated").HasColumnType("date").ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(x => x.DateUpdated).HasColumnName("DateUpdated").HasColumnType("date").ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(x => x.CreatedById).HasColumnName("CreatedById").HasColumnType("varchar(512)").IsRequired(true);
            builder.Property(x => x.UpdatedById).HasColumnName("UpdatedById").HasColumnType("varchar(512)").IsRequired(true);
        }
    }
}

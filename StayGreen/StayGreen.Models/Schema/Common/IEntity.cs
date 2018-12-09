using System;

namespace StayGreen.Models.Schema.Common
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        Guid UpdatedById { get; set; }
        Guid CreatedById { get; set; }
    }
}

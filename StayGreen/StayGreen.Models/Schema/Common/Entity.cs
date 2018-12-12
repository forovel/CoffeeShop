﻿using System;

namespace StayGreen.Models.Schema.Common
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid UpdatedById { get; set; }
        public Guid CreatedById { get; set; }
    }
}
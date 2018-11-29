using Microsoft.AspNetCore.Identity;
using StayGreen.Models.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class Role : IdentityRole<Guid>, IEntity<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid UpdatedById { get; set; }
        public Guid CreatedById { get; set; }
    }
}

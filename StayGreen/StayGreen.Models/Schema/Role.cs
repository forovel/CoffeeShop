using Microsoft.AspNetCore.Identity;
using StayGreen.Models.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class Role : IdentityRole<Guid>, IEntity<Guid>
    {
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid UpdatedById { get; set; }
        public Guid CreatedById { get; set; }

        //Reverse navigation
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RoleClaim> RoleClaims { get; set; }

        public Role()
        {
            UserRoles = new List<UserRole>();
            RoleClaims = new List<RoleClaim>();
        }
    }
}

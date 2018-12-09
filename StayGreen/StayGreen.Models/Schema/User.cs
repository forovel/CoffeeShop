using Microsoft.AspNetCore.Identity;
using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid UpdatedById { get; set; }
        public Guid CreatedById { get; set; }

        //Reverse navigation
        public virtual ICollection<UserRole> UserRoles { get; }
        public virtual ICollection<UserLogin> UserLogins { get; }
        public virtual ICollection<UserToken> UserTokens { get; }
        public virtual ICollection<UserClaim> UserClaims { get; }

        public User()
        {
            UserRoles = new List<UserRole>();
            UserLogins = new List<UserLogin>();
            UserTokens = new List<UserToken>();
            UserClaims = new List<UserClaim>();
        }
    }
}

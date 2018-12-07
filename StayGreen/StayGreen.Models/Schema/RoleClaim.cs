using Microsoft.AspNetCore.Identity;
using System;

namespace StayGreen.Models.Schema
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual Role Role { get; set; }
    }
}

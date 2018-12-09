using Microsoft.AspNetCore.Identity;
using System;

namespace StayGreen.Models.Schema
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        //Foreign keys
        public virtual Role Role { get; set; }
    }
}

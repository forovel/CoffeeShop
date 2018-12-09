using Microsoft.AspNetCore.Identity;
using System;

namespace StayGreen.Models.Schema
{
    public class UserRole : IdentityUserRole<Guid>
    {
        //Foreign keys
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}

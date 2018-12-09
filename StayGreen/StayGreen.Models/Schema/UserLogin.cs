using Microsoft.AspNetCore.Identity;
using System;

namespace StayGreen.Models.Schema
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
        //Foreign keys
        public virtual User User { get; set; }
    }
}

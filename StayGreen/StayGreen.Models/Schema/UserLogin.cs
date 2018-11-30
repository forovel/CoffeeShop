using Microsoft.AspNetCore.Identity;
using System;

namespace StayGreen.Models.Schema
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public User User { get; set; }
    }
}

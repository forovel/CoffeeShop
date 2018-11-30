using Microsoft.AspNetCore.Identity;
using System;

namespace StayGreen.Models.Schema
{
    public class UserClaim : IdentityUserClaim<Guid>
    {
        public User User { get; set; }
    }
}

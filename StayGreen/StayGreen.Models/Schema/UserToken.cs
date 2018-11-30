using Microsoft.AspNetCore.Identity;
using System;

namespace StayGreen.Models.Schema
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public User User { get; set; }
    }
}

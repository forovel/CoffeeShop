﻿using Microsoft.AspNetCore.Identity;
using System;

namespace StayGreen.Models.Schema
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}

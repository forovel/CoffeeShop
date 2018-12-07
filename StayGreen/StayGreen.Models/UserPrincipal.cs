using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace StayGreen.Models
{
    public class UserPrincipal : ClaimsPrincipal
    {
        public UserPrincipal(IPrincipal principal) : base(principal) { }

        public Guid Id { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}

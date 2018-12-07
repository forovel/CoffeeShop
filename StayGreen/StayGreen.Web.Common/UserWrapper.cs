using Microsoft.AspNetCore.Http;
using StayGreen.Common.Constatns;
using StayGreen.Models;
using StayGreen.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace StayGreen.Web.Common
{
    public class UserWrapper : IUserWrapper
    {
        private readonly IHttpContextAccessor _accessor;

        public UserWrapper(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public UserPrincipal CurrentUser => new UserPrincipal(_accessor.HttpContext.User);

        public Guid Id
        {
            get => Guid.Parse(CurrentUser.Claims.FirstOrDefault(x => x.Type == Authorization.Id)?.Value);
        }

        public string Email
        {
            get => CurrentUser.Claims.FirstOrDefault(x => x.Type == Authorization.Email)?.Value;
        }

        public bool IsInRoles(params string[] roles)
        {
            return roles.Any(role => CurrentUser.Roles.Any(x => x == role));
        }

        private IEnumerable<Claim> Roles
        {
            get => CurrentUser.Claims.Where(x => x.Type == Authorization.Roles);
        }
    }
}

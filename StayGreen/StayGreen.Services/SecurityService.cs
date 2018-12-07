using Microsoft.EntityFrameworkCore;
using StayGreen.Common.Exception;
using StayGreen.Common.Query;
using StayGreen.Models;
using StayGreen.Models.Context;
using StayGreen.Models.Dtos.Schemas;
using StayGreen.Models.Schema;
using StayGreen.Services.Common;
using StayGreen.Services.Interfaces;
using StayGreen.Services.Interfaces.Common;
using System;
using System.Linq;
using System.Security.Principal;

namespace StayGreen.Services
{
    public class SecurityService : BaseService<User, UserDto, UserDto, UserDto>, ISecurityService
    {
        private readonly UserPrincipal _currentUser;

        public SecurityService(
            ApplicationDbContext dbContext,
            IUserWrapper userWrapper
            ) 
            : base(dbContext, userWrapper)
        {
            _currentUser = userWrapper.CurrentUser;
        }

        public IPrincipal GetCurrentUser()
        {
            return UserWrapper.CurrentUser;
        }

        public bool IsUserInRoles(params Guid[] roles)
        {
            if (_currentUser == null) return false;

            var dbUser = DbContext.Users.Include(x => x.UserRoles).FirstOrDefault(x => x.Email == UserWrapper.Email);
            if (dbUser == null)
            {
                return false;
            }

            var userRoles = from x in dbUser.UserRoles
                            join role in DbContext.Roles on x.RoleId equals role.Id
                            select role;

            foreach (var role in roles)
            {
                if (userRoles.Select(x => x.Id).Contains(role))
                {
                    return true;
                }
            }

            return false;
        }

        public void MustBeInRoles(params Guid[] roles)
        {
            if (_currentUser == null || !IsUserInRoles(roles))
            {
                throw new StayGreenPermissionException();
            }
        }

        public override PaginatedList<UserDto> GetFiltered(IQueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }
    }
}

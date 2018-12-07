using System;
using System.Security.Principal;

namespace StayGreen.Services.Interfaces
{
    public interface ISecurityService
    {
        void MustBeInRoles(params Guid[] roles);
        bool IsUserInRoles(params Guid[] roles);
        IPrincipal GetCurrentUser();
    }
}

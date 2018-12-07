using StayGreen.Models;
using System;

namespace StayGreen.Services.Interfaces
{
    public interface IUserWrapper
    {
        Guid Id { get; }
        string Email { get; }
        UserPrincipal CurrentUser { get; }
        bool IsInRoles(params string[] roles);
    }
}

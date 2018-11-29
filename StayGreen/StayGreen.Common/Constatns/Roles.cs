using System;
using System.Collections.Generic;
using System.Linq;

namespace StayGreen.Common.Constatns
{
    public static class Roles
    {
        public static Guid Superadmin { get; } = Guid.Parse("ac5d8fe4-c04d-4f49-9512-b78574206334");
        public static Guid Admin { get; } = Guid.Parse("cf186a9d-d8db-4624-94a2-ce5149b14697");
        public static Guid Client { get; } = Guid.Parse("63bc2642-4410-44a3-b033-5e6bd0874409");

        static readonly IDictionary<string, Guid> RoleNames;

        static Roles()
        {
            RoleNames = new Dictionary<string, Guid>
            {
                { "Superadmin", Superadmin },
                { "Admin", Admin },
                { "Client", Client } };
        }

        public static Guid? GetRoleByName(string roleName)
        {
            if (RoleNames.ContainsKey(roleName))
            {
                return RoleNames[roleName];
            }

            return null;
        }

        public static string GetRoleNameById(Guid roleId)
        {
            return RoleNames.FirstOrDefault(x => x.Value == roleId).Key;
        }

    }

    public static class StringRoles
    {
        public static string Superadmin { get; } = "Superadmin";
        public static string Admin { get; } = "Admin";
        public static string Client { get; } = "Client";
    }
}

using System;
using Common.Security;
using Entities;

namespace Client.Web.Test
{
    public class StubData
    {
        internal static UserPrincipal CreateSimplPrincipal()
        {
            var systemUser = new SystemUser();
            return new UserPrincipal(systemUser, Guid.NewGuid());
        }

        internal static UserPrincipal CreateVipPrincipal()
        {
            var systemUser = new SystemUser();
            return new UserPrincipal(systemUser, Guid.NewGuid());
        }

        internal static UserPrincipal CreateAdminPrincipal()
        {
            var systemUser = new SystemUser();
            return new UserPrincipal(systemUser, Guid.NewGuid());
        }

        internal static UserPrincipal CreateSuPrincipal()
        {
            var systemUser = new SystemUser();
            return new UserPrincipal(systemUser, Guid.NewGuid());
        }
    }
}

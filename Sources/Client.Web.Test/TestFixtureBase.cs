using Common.Security;

namespace Client.Web.Test
{
    public class TestFixtureBase
    {
        protected virtual void LogAsEmpty()
        {
            UserPrincipal.CurrentUser = UserPrincipal.Empty;
        }

        protected virtual void LogAsStubSimpl()
        {
            UserPrincipal.CurrentUser = StubData.CreateSimplPrincipal();
        }

        protected virtual void LogAsStubVip()
        {
            UserPrincipal.CurrentUser = StubData.CreateVipPrincipal();
        }

        protected virtual void LogAsStubAdmin()
        {
            UserPrincipal.CurrentUser = StubData.CreateAdminPrincipal();
        }

        protected virtual void LogAsStubSu()
        {
            UserPrincipal.CurrentUser = StubData.CreateSuPrincipal();
        }

        public virtual void Logout()
        {
            UserPrincipal.CurrentUser = UserPrincipal.Empty;
        }
    }
}

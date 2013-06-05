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
            UserPrincipal.CurrentUser = StubData.Instance.CreateSimplPrincipal();
        }

        protected virtual void LogAsStubVIP()
        {
            UserPrincipal.CurrentUser = StubData.Instance.CreateVIPPrincipal();
        }

        protected virtual void LogAsStubAdmin()
        {
            UserPrincipal.CurrentUser = StubData.Instance.CreateAdminPrincipal();
        }

        protected virtual void LogAsStubSu()
        {
            UserPrincipal.CurrentUser = StubData.Instance.CreateSuPrincipal();
        }


        public virtual void Logout()
        {
            UserPrincipal.CurrentUser = UserPrincipal.Empty;
        }
    }
}

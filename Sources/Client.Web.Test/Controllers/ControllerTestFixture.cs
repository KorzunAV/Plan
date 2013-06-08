using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Client.Web.Controllers;
using Client.Web.IoC;
using Data.IoC;
using MvcContrib.TestHelper;
using MvcContrib.TestHelper.Fakes;
using NUnit.Framework;
using Ninject;
using Rhino.Mocks;

namespace Client.Web.Test.Controllers
{
    //TODO: KOA: часть кода
    public class ControllerTestFixture<T> : TestFixtureBase
        where T : BaseController
    {
        private StandardKernel _kernel;
        protected TestControllerBuilder _testControllerBuilder;
        protected T Controller { get; set; }


        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
            _kernel = new StandardKernel(
                new DataModule(),
                new ControllersModule());
            _testControllerBuilder = new TestControllerBuilder(new RhinoMocksFactory());

            //IRoutesRegistrator routesRegistrator = SpringContext.GetObject<IRoutesRegistrator>();
            //routesRegistrator.Clear(RouteTable.Routes);
            //routesRegistrator.Register(RouteTable.Routes);
        }

        [SetUp]
        public virtual void SetUp()
        {
            Controller = _kernel.Get<T>();
           
            _testControllerBuilder.InitializeController(Controller);
            var requestContext = new RequestContext(new FakeHttpContext("~/"), new RouteData());
            Controller.Url = new UrlHelper(requestContext, RouteTable.Routes);
            if (Controller.Response.Cookies == null)
            {
                var cookies = new HttpCookieCollection();
                Controller.Response.Expect(r => r.Cookies).Return(cookies).Repeat.Any();
            }
            LogAsEmpty();
        }

        [TearDown]
        public virtual void TearDown()
        {
            Controller.ModelState.Clear();
            //Controller.SessionStorage.Clear();
        }
    }
}

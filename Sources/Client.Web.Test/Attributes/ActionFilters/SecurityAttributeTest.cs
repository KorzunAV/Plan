using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client.Web.ActionResults;
using Client.Web.Attributes.ActionFilters;
using NUnit.Framework;
using Rhino.Mocks;

namespace Client.Web.Test.Attributes.ActionFilters
{
    [TestFixture]
    public class SecurityAttributeTest
    {
        [Test]
        public void AttributeUsageTest()
        {
            AttributeUsageAttribute attribute =
                typeof(SecurityAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), true).Cast
                    <AttributeUsageAttribute>().First();
            Assert.IsFalse(attribute.AllowMultiple);
            Assert.IsTrue(attribute.Inherited);
            Assert.AreEqual(attribute.ValidOn, AttributeTargets.Method | AttributeTargets.Class);
        }

        [Test]
        public void OnActionExecutingWithSecurityTest()
        {
            MockRepository mockRepo = new MockRepository();
            ActionExecutingContext context = mockRepo.DynamicMock<ActionExecutingContext>();
            SecurityAttribute attribute = mockRepo.PartialMock<SecurityAttribute>();

            Expect.Call(attribute.HasPermission(context)).Return(true);
            mockRepo.ReplayAll();
            attribute.OnActionExecuting(context);
            mockRepo.VerifyAll();
            Assert.IsFalse(context.Result is RedirectToLoginResult);
        }

        [Test]
        public void OnActionExecutingWithoutSecurityTest()
        {
            MockRepository mockRepo = new MockRepository();
            ActionExecutingContext context = mockRepo.PartialMock<ActionExecutingContext>();
            SecurityAttribute attribute = mockRepo.PartialMock<SecurityAttribute>();
            HttpContextBase httpContext = mockRepo.PartialMock<HttpContextBase>();
            HttpRequestBase httpRequest = mockRepo.PartialMock<HttpRequestBase>();

            Expect.Call(httpRequest.RawUrl).Return("TestUrl").Repeat.Any();
            Expect.Call(httpContext.Request).Return(httpRequest).Repeat.Any();
            Expect.Call(context.HttpContext).Return(httpContext).Repeat.Any();
            Expect.Call(attribute.HasPermission(context)).Return(false);
            attribute.Expect(x => x.ProccessNoPermissionResult(context)).Do(
                (Action<ActionExecutingContext>)(filterContext => filterContext.Result = new RedirectToLoginResult()));

            mockRepo.ReplayAll();
            attribute.OnActionExecuting(context);
            mockRepo.VerifyAll();
            Assert.IsTrue(context.Result is RedirectToLoginResult);
        }
    }
}
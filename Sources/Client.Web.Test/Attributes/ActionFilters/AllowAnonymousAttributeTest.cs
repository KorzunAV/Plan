using System;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using Rhino.Mocks;

namespace Client.Web.Test.Attributes.ActionFilters
{
    [TestFixture]
    public class AllowAnonymousAttributeTest
    {
        [Test]
        public void AttributeUsageTest()
        {
            AttributeUsageAttribute attribute = typeof(AllowAnonymousAttribute)
                .GetCustomAttributes(typeof(AttributeUsageAttribute), true)
                .Cast<AttributeUsageAttribute>()
                .First();
            Assert.IsFalse(attribute.AllowMultiple);
            Assert.IsTrue(attribute.Inherited);
            Assert.AreEqual(attribute.ValidOn, AttributeTargets.Method | AttributeTargets.Class);
        }

        [Test]
        public void HasPermissionTest()
        {
            var attribute = new Web.Attributes.ActionFilters.AllowAnonymousAttribute();
            var mockRepo = new MockRepository();
            var context = mockRepo.DynamicMock<ActionExecutingContext>();
            mockRepo.ReplayAll();
            Assert.IsTrue(attribute.HasPermission(context));
            mockRepo.VerifyAll();
        }
    }
}

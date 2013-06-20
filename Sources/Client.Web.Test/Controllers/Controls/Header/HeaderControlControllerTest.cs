using System.Web.Mvc;
using Client.Web.Controllers.Controls.Header;
using NUnit.Framework;

namespace Client.Web.Test.Controllers.Controls.Header
{
    [TestFixture]
    public class HeaderControlControllerTest : ControllerTestFixture<HeaderControlController>
    {
        [Test]
        public void IndexActionAttributeTest()
        {
            var attr = Controller.GetType()
                .GetMethod(HeaderControlController.IndexAction)
                .GetCustomAttributes(typeof(ChildActionOnlyAttribute), false);
            Assert.IsNotEmpty(attr, "Index action should be marked with ChildActionOnlyAttribute, because it is not a public action, which could be called via user browser");
        }


        [Test]
        public void IndexUnknownUserTest()
        {
            LogAsEmpty();
            PartialViewResult result = Controller.Index();
            Assert.IsTrue(result.ViewName == HeaderControlController.HeaderControlPath);
        }
    }
}

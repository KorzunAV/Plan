using System.Web.Mvc;
using Client.Web.Controllers.Controls.Footer;
using Client.Web.Models.Controls.Footer;
using NUnit.Framework;

namespace Client.Web.Test.Controllers.Controls.Footer
{
    [TestFixture]
    public class FooterControlControllerTest : ControllerTestFixture<FooterControlController>
    {
        [Test]
        public void IndexActionAttributeTest()
        {
            var attr = Controller.GetType()
                .GetMethod(FooterControlController.IndexAction)
                .GetCustomAttributes(typeof(ChildActionOnlyAttribute), false);
            Assert.IsNotEmpty(attr, "Index action should be marked with ChildActionOnlyAttribute, because it is not a public action, which could be called via user browser");
        }


        [Test]
        public void IndexUnknownUserTest()
        {
            LogAsEmpty();
            // HAL: The test should be changed when appropriate functionality will be added for tenders footer items
            PartialViewResult result = Controller.Index();
            Assert.IsTrue(result.ViewName == FooterControlController.FooterControlPath);
            var model = (FooterModel) result.Model;
            Assert.False(model.IsMyAccountEnabled);
        }

        [Test]
        public void IndexSuTest()
        {
            LogAsStubSu();

            PartialViewResult result = Controller.Index();
            Assert.IsTrue(result.ViewName == FooterControlController.FooterControlPath);
            var model = (FooterModel) result.Model;
            Assert.True(model.IsMyAccountEnabled);
        }
    }
}

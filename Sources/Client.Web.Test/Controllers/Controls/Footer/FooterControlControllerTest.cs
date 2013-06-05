using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;

namespace Client.Web.Test.Controllers.Controls.Footer
{
     [TestFixture]
    public class FooterControlControllerTest : ControllerTestFixture<FooterControlController>
    {
        [Test]
        public void IndexUnknownUserTest()
        {
            // HAL: The test should be changed when appropriate functionality will be added for tenders footer items
            PartialViewResult result = Controller.Index();
            Assert.IsTrue(result.ViewName == FooterControlController.FooterControlPath);
            FooterModel model = (FooterModel)result.Model;
            Assert.IsTrue(model.IsProcurementEnabled);
            Assert.IsTrue(model.IsMyCataloguesEnabled);
            //SAK: "Online Store" module hidden until not ready
            Assert.IsFalse(model.IsMyStoresEnabled);
            // Test the part which specified for CMP only
            Assert.IsFalse(model.IsTendersEnabled);
            Assert.IsFalse(model.IsPQQsEnabled);
            Assert.IsFalse(model.IsMyTendersEnabled);
            Assert.IsFalse(model.IsTendersAdministrationEnabled);
        }

        [Test]
        public void IndexSUTest()
        {
            // HAL: The test should be changed when appropriate functionality will be added for tenders footer items
            LogAsStubSu();

            PartialViewResult result = Controller.Index();
            Assert.IsTrue(result.ViewName == FooterControlController.FooterControlPath);
            FooterModel model = (FooterModel)result.Model;
            Assert.IsFalse(model.IsProcurementEnabled);
            Assert.IsFalse(model.IsMyCataloguesEnabled);
            Assert.IsFalse(model.IsMyStoresEnabled);
            // Test the part which specified for CMP only
            Assert.IsFalse(model.IsTendersEnabled);
            Assert.IsFalse(model.IsPQQsEnabled);
            Assert.IsFalse(model.IsMyTendersEnabled);
            Assert.IsFalse(model.IsTendersAdministrationEnabled);
        }
}

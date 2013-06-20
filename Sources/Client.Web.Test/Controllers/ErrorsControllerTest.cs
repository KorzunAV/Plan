using System.Web.Mvc;
using Client.Web.Controllers;
using NUnit.Framework;

namespace Client.Web.Test.Controllers
{
	[TestFixture]
	public class ErrorsControllerTest : ControllerTestFixture<ErrorsController>
	{
		[Test]
		public void ControllerSecurityTest()
		{
			object[] attributes = typeof(ErrorsController).GetCustomAttributes(typeof(AllowAnonymousAttribute), true);
			Assert.IsTrue(attributes.Length == 1);
			Assert.IsNotNull(attributes[0]);
		}
		
		[Test]
		public void PageNotFoundTest()
		{
			ViewResult result = Controller.PageNotFound();
			Assert.IsNotNull(result);
		}

		[Test]
		public void UnknownTest()
		{
			ViewResult result = Controller.Unknown();
			Assert.IsNotNull(result);
		}

		[Test]
		public void ObjectNotFoundTest()
		{
			ViewResult result = Controller.ObjectNotFound();
			Assert.IsNotNull(result);
		}

		[Test]
		public void NoPermissionTest()
		{
			ViewResult result = Controller.NoPermission();
			Assert.IsNotNull(result);
		}
	}
}

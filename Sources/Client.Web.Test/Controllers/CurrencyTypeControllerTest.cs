using System.Web.Mvc;
using Client.Web.Attributes;
using Client.Web.Controllers;
using NUnit.Framework;
using System.Linq;

namespace Client.Web.Test.Controllers
{
	[TestFixture]
	public class CurrencyTypeControllerTest : ControllerTestFixture<CurrencyTypeController>
	{

		[Test]
		public void SecurityAttributesTest()
		{
			Assert.IsNotNull(Controller.GetType().GetCustomAttributes(typeof(AuthorizeAttribute), true)[0]);

			IsInRoleAttribute attribute = Controller.GetType()
				.GetCustomAttributes(typeof(IsInRoleAttribute), true)
				.Cast<IsInRoleAttribute>().ToList()[0];
			Assert.IsTrue(attribute.Roles.Count == 2);
			Assert.IsTrue(attribute.Roles.Contains(Constants.Roles.AdminPrincipal));
			Assert.IsTrue(attribute.Roles.Contains(Constants.Roles.SuPrincipal));
		}

		[Test]
		public void IndexUnknownUserTest()
		{
			LogAsEmpty();
			var result = Controller.Index();
		}

		[Test]
		public void IndexSuTest()
		{
			LogAsStubSu();
			var result = Controller.Index();
		}
	}
}

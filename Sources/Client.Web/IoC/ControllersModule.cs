using Client.Web.Controllers;
using Client.Web.Controllers.Controls.Footer;
using Client.Web.Controllers.Controls.Header;
using Ninject.Modules;

namespace Client.Web.IoC
{
	public class ControllersModule : NinjectModule
	{
		public override void Load()
		{
			Bind<MainGridController>()
			  .ToSelf();

			Bind<CurrencyTypeController>()
			  .ToSelf();

			Bind<FooterControlController>()
				.ToSelf();

			Bind<HeaderControlController>()
				.ToSelf();
		}
	}
}
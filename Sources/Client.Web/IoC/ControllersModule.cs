using Client.Web.Controllers;
using Client.Web.Controllers.Controls;
using Client.Web.Controllers.Controls.Footer;
using Client.Web.Controllers.Controls.Header;
using Common.Data.Core;
using Ninject;
using Ninject.Modules;

namespace Client.Web.IoC
{
    public class ControllersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<TestGridController>()
               .ToSelf()
               .WithConstructorArgument("Dao", Kernel.Get<IBaseDao>());

            Bind<FooterControlController>()
                .ToSelf();

            Bind<HeaderControlController>()
                .ToSelf();
        }
    }
}
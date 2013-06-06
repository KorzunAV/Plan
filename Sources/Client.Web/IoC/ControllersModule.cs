using Client.Web.Controllers;
using Client.Web.Controllers.Controls.Footer;
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
               .InSingletonScope()
               .WithConstructorArgument("Dao", Kernel.Get<IBaseDao>());

            Bind<FooterControlController>()
                .ToSelf()
                .InSingletonScope();
        }
    }
}
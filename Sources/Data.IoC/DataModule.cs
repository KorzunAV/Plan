using Common.Data.Core;
using Data.NHibernate;
using Ninject.Modules;
using System.Configuration;

namespace Data.IoC
{
	public class DataModule : NinjectModule
	{
		public override void Load()
		{
            Bind<IConditionResolver>()
                .To<ConditionResolver>()
                .InSingletonScope();

			Bind<IBaseDao>()
				.To<BaseDao>()
				.InSingletonScope()
				.WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString);

		}
	}
}

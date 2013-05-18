using Data.NHibernate;
using Entities.Entity;
using Ninject.Modules;
using System.Configuration;

namespace Data.IoC
{
	public class DataModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IBaseDao>()
				.To<BaseDao>()
				.InSingletonScope()
				.WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString);
		}
	}
}

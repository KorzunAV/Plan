using System;
using Entities.Entity;
using FluentNHibernate.Automapping;

namespace Data.NHibernate
{
	class AutomappingConfiguration : DefaultAutomappingConfiguration
	{
		public override bool ShouldMap(Type type)
		{
			//Берем сущьности из сборки с EntityBase
			return type.Namespace == typeof(EntityBase).Namespace;
		}

		public override bool IsComponent(Type type)
		{
			// исключаем из БД
			return type == typeof(EntityBase);
		}
	}
}
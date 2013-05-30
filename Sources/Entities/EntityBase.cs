using System;
using System.Linq.Expressions;
using Common.Data.Core;

namespace Entities
{
	/// <summary>
	/// Базовый класс для сущьностей
	/// </summary>
	public class EntityBase : IEntityBase
	{

		#region IEntityBase Members

		/// <summary>
		/// Уникальный идентификатор
		/// </summary>
		public virtual int Id { get; set; }

		/// <summary>
		/// Версия
		/// </summary>
		public virtual int Version { get; set; }

		#endregion

		/// <summary>
		/// Получаем имя свойства.
		/// </summary>
		/// <param name="action">Лямда оператор.</param>
		/// <returns>Имя свойства.</returns>
		public static string GetFieldName<T>(Expression<Func<T, object>> action)
			where T : class, IEntityBase
		{
			return ClassNameHelper.GetFieldName(action);
		}
	}
}
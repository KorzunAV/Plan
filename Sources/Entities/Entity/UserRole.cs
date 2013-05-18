namespace Entities.Entity
{
	/// <summary>
	/// Роль пользователя.
	/// </summary>
	public class UserRole
	{
		public virtual int Id { get; protected set; }

		/// <summary>
		/// Версия
		/// </summary>
		public virtual int Version { get; set; }

		/// <summary>
		/// Название роли.
		/// </summary>
		public virtual string Name { get; set; }
	}
}
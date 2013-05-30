namespace Entities
{
	/// <summary>
	/// Пользователь системы
	/// </summary>
	public class SystemUser : EntityBase
	{
		/// <summary>
		/// Имя или псевдоним пользователя.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// Логин входа в систему.
		/// </summary>
		public virtual string Login { get; set; }

		/// <summary>
		/// Пароль входа в систему.
		/// </summary>
		public virtual string Password { get; set; }
		
		/// <summary>
		/// Роль пользователя.
		/// </summary>
		public virtual UserRole UserRole { get; set; }
	}
}
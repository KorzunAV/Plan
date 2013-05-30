namespace Entities
{
	/// <summary>
	/// Пользовательский тег.
	/// </summary>
	public class Tag : EntityBase
	{
		/// <summary>
		/// Название.
		/// </summary>
		public virtual string Name { get; set; }
		
		/// <summary>
		/// Пользователь.
		/// </summary>
		public virtual SystemUser SystemUser { get; set; }
	}
}
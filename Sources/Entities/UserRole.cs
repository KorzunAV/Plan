namespace Entities
{
    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public class UserRole : EntityBase
    {
        /// <summary>
        /// Название роли.
        /// </summary>
        public virtual string Name { get; set; }
    }
}
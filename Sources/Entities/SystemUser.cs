
namespace Entities
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class SystemUser : EntityBase
    {
        //значения по умолчанию
        private string _name = string.Empty;
        private UserRole _userRole = new UserRole();

        /// <summary>
        /// Имя или псевдоним пользователя.
        /// </summary>
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Логин входа в систему.
        /// </summary>
        public virtual string Login { get; set; }

        /// <summary>
        /// Пароль входа в систему.
        /// </summary>
        public virtual string PasswordHash { get; set; }
        
        /// <summary>
        /// Роль пользователя.
        /// </summary>
        public virtual UserRole UserRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }

        public virtual string Culture { get; set; }
    }
}
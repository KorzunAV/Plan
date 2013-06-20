using System;
using System.Collections.Generic;
using System.Security.Principal;
using Entities;

namespace Common.Security
{
	[Serializable]
	public class UserPrincipal : GenericPrincipal, ICloneable
	{
		private static readonly UserPrincipal _empty = new UserPrincipal();
	
		public SystemUser SystemUser { get; protected set; }

		public Guid SessionId { get; set; }

		/// <summary>
		/// Empty use principal. Uses for non-authorized users
		/// </summary>
		public static UserPrincipal Empty
		{
			get { return _empty; }
		}

		/// <summary>
		/// Gets or sets the user associated with the current executing thread.
		/// </summary>
		public static UserPrincipal CurrentUser
		{
			get
			{
				var principal = System.Threading.Thread.CurrentPrincipal as UserPrincipal;

				if (principal == null)
				{
					return Empty;
				}
				return principal;
			}
			set { System.Threading.Thread.CurrentPrincipal = value; }
		}

		/// <summary>
		/// Get whether current user in authenticated
		/// </summary>
		public static bool IsAuthenticated
		{
			get { return CurrentUser != null && CurrentUser != Empty; }
		}

		#region Constructors

		/// <summary>
		/// Private constructor of class. Uses for creating of Empty instance of the object
		/// </summary>
		private UserPrincipal()
			: this(new SystemUser { UserRole = new UserRole() }, Guid.Empty)
		{
		}

		/// <summary>
		/// Constructor of class
		/// </summary>
		/// <param name="systemUser">Системный пользователь</param>
		/// <param name="sessionId">Identity of session</param>
		public UserPrincipal(SystemUser systemUser, Guid sessionId)
			: this(new GenericIdentity(systemUser.Name), systemUser, sessionId) { }

		/// <summary>
		/// Constructor of class
		/// </summary>
		/// <param name="identity">Базовая реализация объекта <see cref="T:System.Security.Principal.IIdentity"/>, представляющего любого пользователя.</param>
		/// <param name="systemUser">Системный пользователь</param>
		/// <param name="sessionId">Identity of session</param>
		public UserPrincipal(IIdentity identity, SystemUser systemUser, Guid sessionId)
			: base(identity, new[] { systemUser.UserRole.Id.ToString() })
		{
			SessionId = sessionId;
			SystemUser = systemUser;
		}

		#endregion Constructors

		/// <summary>
		/// Check is user in role
		/// </summary>
		/// <param name="role">Role id</param>
		/// <returns></returns>
		public bool IsInRole(Guid role)
		{
			return SystemUser.UserRole.Id == role;
		}

		public static string GetCulture
		{
			get
			{
				if (CurrentUser != null)
				{
					return CurrentUser.SystemUser.Culture;
				}
				return string.Empty;
			}
		}

		#region ICloneable Members

		public object Clone()
		{
			var clone = new UserPrincipal(Identity, SystemUser, SessionId);
			return clone;
		}

		#endregion
	}
}

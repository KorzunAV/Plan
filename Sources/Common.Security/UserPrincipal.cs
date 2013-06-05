using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Common.Security
{
    [Serializable]
    public class UserPrincipal : GenericPrincipal, ICloneable
    {
        public Guid Id { get; protected set; }

        public Guid SessionId { get; set; }

        public string Name
        {
            get { return Identity.Name; }
        }

        public List<Guid> RoleTypes { get; protected set; }

        /// <summary>
        /// Permissions of the user
        /// </summary>
        public List<Guid> Permissions { get; protected set; }

        /// <summary>
        /// Flag, showing whether user has accepted Marketplace's terms of use
        /// </summary>
        public bool TermsOfUseAccepted { get; set; }



        private static readonly UserPrincipal _empty = new UserPrincipal();
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
            : this(Guid.Empty, String.Empty, Guid.Empty, new List<Guid>(), new List<Guid>(), false)
        {
        }


        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <param name="name">User name</param>
        /// <param name="sessionId">Identigier of session</param>
        /// <param name="permissions">User permisions</param>
        /// <param name="roles">User roles</param>
        /// <param name="mpTermsOfUseAccepted">Flag, showing whether user has accepted Marketplace's terms of use</param>
        public UserPrincipal(Guid id, string name, Guid sessionId, List<Guid> permissions, List<Guid> roles, bool mpTermsOfUseAccepted)
            : this(new GenericIdentity(name), id, sessionId, permissions, roles, mpTermsOfUseAccepted)
        {
        }

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <param name="identity">Identity object</param>
        /// <param name="sessionId">Identity of session</param>
        /// <param name="permissions">Permissions of the user</param>
        /// <param name="roles">User roles</param>
        /// <param name="termsOfUseAccepted">Flag, showing whether user has accepted terms of use</param>
        public UserPrincipal(IIdentity identity, Guid id, Guid sessionId, List<Guid> permissions, List<Guid> roles, bool termsOfUseAccepted)
            : base(identity, roles.Select(r => r.ToString()).ToArray())
        {
            Id = id;
            SessionId = sessionId;
            RoleTypes = roles;
            Permissions = permissions;
            TermsOfUseAccepted = termsOfUseAccepted;
        }

        #endregion Constructors

        /// <summary>
        /// Cheeck user permission to the passed resource
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public bool HasPermission(Guid permission)
        {
            return Permissions.Contains(permission);
        }

        /// <summary>
        /// Check is user in role
        /// </summary>
        /// <param name="role">Role id</param>
        /// <returns></returns>
        public bool IsInRole(Guid role)
        {
            return RoleTypes.Contains(role);
        }
        

        #region ICloneable Members

        public object Clone()
        {
            var clone = new UserPrincipal(Identity, Id, SessionId, new List<Guid>(Permissions), new List<Guid>(RoleTypes), TermsOfUseAccepted);
            return clone;
        }

        #endregion
    }
}

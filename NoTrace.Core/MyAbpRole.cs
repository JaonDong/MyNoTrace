using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNet.Identity;
using NoTrace.MultiTenancy;
using NoTrace.Users;

namespace NoTrace.Authorization
{
    /// <summary>
    /// Represents a role in an application. A role is used to group permissions.
    /// </summary>
    /// <remarks> 
    /// Application should use permissions to check if user is granted to perform an operation.
    /// Checking 'if a user has a role' is not possible until the role is static (<see cref="IsStatic"/>).
    /// Static roles can be used in the code and can not be deleted by users.
    /// Non-static (dynamic) roles can be added/removed by users and we can not know their name while coding.
    /// A user can have multiple roles. Thus, user will have all permissions of all assigned roles.
    /// </remarks>
    public class MyAbpRole<TTenant,TUser>:FullAuditedEntity<int,TUser>,IRole<int>
        where TTenant:MyAbpTenant<TTenant,TUser>
        where TUser:MyAbpUser<TTenant,TUser>
    {
        #region Fields
        #region Only data fields
        [Required]
        public virtual string Name { get; set; }
        #endregion
        public virtual int? TenantId { get; set; }
        [ForeignKey("TenantId")]
        public virtual TTenant Tenant { get; set; }
        /// <summary>
        /// Is this a static role?
        /// Static roles can not be deleted, can not change their name.
        /// They can be used programmatically.
        /// </summary>
        public virtual bool IsStatic { get; set; }

        /// <summary>
        /// Is this role will be assigned to new users as default?
        /// </summary>
        public virtual bool IsDefault { get; set; } 
        #endregion

        public MyAbpRole()
        {
            Name = Guid.NewGuid().ToString("N");
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace NoTrace.Users
{
    [Table("UserRoles")]
    public class UserRole: CreationAuditedEntity<long>
    {
         public virtual long UserId { get; set; }

        public virtual int RoleId { get; set; }

        public UserRole() { }

        public UserRole(long userId,int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using NoTrace.Users;

namespace NoTrace.MultiTenancy
{
    public abstract class MyAbpTenant<TTenant, TUser> : FullAuditedEntity<int, TUser>, IPassivable
        where TTenant : MyAbpTenant<TTenant, TUser>
        where TUser : MyAbpUser<TTenant, TUser>
    {
        #region Fields

        #region Only data fields
        [Required]
        public virtual string Name { get; set; }
        #endregion
        /// <summary>
        /// 租户如果是未激活状态，则所属该租户下的所有都不能使用
        /// </summary>
        public virtual bool IsActive { get; set; }
        #endregion

        protected MyAbpTenant()
        {
            IsActive = true;
        }
    }
}
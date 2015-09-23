using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNet.Identity;
using MyAbp.Core.MultiTenancy;

namespace MyAbp.Core.Users
{
    public class MyAbpUser<TTenant,TUser> : FullAuditedEntity<long, TUser>,IUser<long>, IPassivable
        where TTenant:MyAbpTenant<TTenant,TUser>
       where TUser : MyAbpUser<TTenant,TUser>
    {

        #region Fields

        #region only data field
        [Required]
        public string UserName { get; set; } 
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        public string EmailConfiremationCode { get; set; }
        /// <summary>
        /// Reset password code
        /// It's not vaild if it is null
        /// It's one usage and must set to null after reset
        /// </summary>
        public string ResetPasswordCode { get; set; }
        public DateTime? LastLoginTime { get; set; }
        #endregion

        /// <summary>
        /// The virtual is  used    late implement
        /// </summary>
        public virtual int? TenatId { get; set; }
        /// <summary>
        /// Is the <see cref="EmailAddress"/> confirmed
        /// </summary>
        public bool IsEmailConfirmed { get; set; }
        public virtual bool IsActive { get; set; }
        #endregion

        #region constructor
        public MyAbpUser()
        {
            IsActive = true;
        } 
        #endregion

        #region Navigation property
        [ForeignKey("TenatId")]
        public virtual TTenant Tenant { get; set; } 
        #endregion
    }
}
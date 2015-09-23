using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace NoTrace.Users
{
    [Table("UserLogin")]
    public class UserLogin:Entity<long>
    {
        public virtual long UserId { get; set; }

        [Required]
        public virtual string LoginProvider { get; set; }
        [Required]
        public virtual string ProviderKey { get; set; }
    }
}
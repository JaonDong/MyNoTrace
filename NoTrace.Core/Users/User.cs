using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization;
using NoTrace.MultiTenancy;

namespace NoTrace.Users
{
    [Table("Users")]
    public class User:MyAbpUser<Tenant,User>
    {
         
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using NoTrace.MultiTenancy;
using NoTrace.Users;

namespace NoTrace.Authorization
{
    [Table("Roles")]
    public class Role:MyAbpRole<Tenant,User>
    {
         
    }
}
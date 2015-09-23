using System.ComponentModel.DataAnnotations.Schema;
using NoTrace.Users;

namespace NoTrace.MultiTenancy
{
    [Table("Tenants")]
    public class Tenant:MyAbpTenant<Tenant,User>
    {
         
    }
}
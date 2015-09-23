using NoTrace.MultiTenancy;
using NoTrace.Users;

namespace NoTrace.Authorization
{
    public class Role:MyAbpRole<Tenant,User>
    {
         
    }
}
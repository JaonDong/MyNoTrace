using NoTrace.Authorization;
using NoTrace.MultiTenancy;

namespace NoTrace.Users
{
    public class NoTraceUserManager : MyAboUserManager<Tenant, User, Role>
    {
        public NoTraceUserManager(NoTraceUserStore store)
            : base(store)
        {
        }
    }
}
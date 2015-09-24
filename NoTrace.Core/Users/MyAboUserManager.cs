using Microsoft.AspNet.Identity;
using NoTrace.Authorization;
using NoTrace.MultiTenancy;

namespace NoTrace.Users
{
    public abstract class MyAboUserManager<TTenant, TUser, TRole> : UserManager<TUser, long>
        where TUser : MyAbpUser<TTenant, TUser>
        where TTenant : MyAbpTenant<TTenant, TUser>
        where TRole : MyAbpRole<TTenant, TUser>
    {
        protected MyAboUserManager(MyAbpUserStore<TTenant, TRole, TUser> store)
            : base(store)
        {

        }
    }
}
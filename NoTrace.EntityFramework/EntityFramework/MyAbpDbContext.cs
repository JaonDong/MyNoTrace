using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using NoTrace.Authorization;
using NoTrace.MultiTenancy;
using NoTrace.Users;

namespace NoTrace.EntityFramework
{
    public class MyAbpDbContext<TTenant, TUser, TRole> : AbpDbContext
        where TTenant : MyAbpTenant<TTenant, TUser>
        where TUser : MyAbpUser<TTenant, TUser>
        where TRole : MyAbpRole<TTenant, TUser>
    {
        //TODO: Define an IDbSet for each Entity...

        public virtual IDbSet<TTenant> Tenants { get; set; }
        public virtual IDbSet<TUser> Users { get; set; }
        public virtual IDbSet<TRole> Roles { get; set; }

        public virtual IDbSet<UserLogin> UserLogins { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */


        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in NoTraceDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of NoTraceDbContext since ABP automatically handles it.
         */
        public MyAbpDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public MyAbpDbContext(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {

        }
    }
}
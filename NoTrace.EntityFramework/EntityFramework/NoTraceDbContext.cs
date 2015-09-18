using Abp.EntityFramework;

namespace NoTrace.EntityFramework
{
    public class NoTraceDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public NoTraceDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in NoTraceDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of NoTraceDbContext since ABP automatically handles it.
         */
        public NoTraceDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}

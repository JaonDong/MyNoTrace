using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using NoTrace.EntityFramework;

namespace NoTrace
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(NoTraceCoreModule))]
    public class NoTraceDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<NoTraceDbContext>(null);
        }
    }
}

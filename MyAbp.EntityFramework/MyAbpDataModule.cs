using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using MyAbp.Core;


namespace MyAbp.EntityFramework
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(MyAbpCoreModule))]
    public class MyAbpDataModule : AbpModule
    {
      
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

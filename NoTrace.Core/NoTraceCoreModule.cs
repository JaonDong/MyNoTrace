using System.Reflection;
using Abp.Modules;

namespace NoTrace
{
    public class NoTraceCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

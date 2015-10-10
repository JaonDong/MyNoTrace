using System.Reflection;
using Abp.Modules;

namespace NoTrace
{
    [DependsOn(typeof(NoTraceCoreModule))]
    public class NoTraceApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //automap setting
            DtoMappings.Map();
        }
    }
}

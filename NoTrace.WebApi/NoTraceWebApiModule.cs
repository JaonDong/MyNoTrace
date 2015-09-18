using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace NoTrace
{
    [DependsOn(typeof(AbpWebApiModule), typeof(NoTraceApplicationModule))]
    public class NoTraceWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(NoTraceApplicationModule).Assembly, "app")
                .Build();
        }
    }
}

using Abp.Application.Services;

namespace NoTrace
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class NoTraceAppServiceBase : ApplicationService
    {
        protected NoTraceAppServiceBase()
        {
            LocalizationSourceName = NoTraceConsts.LocalizationSourceName;
        }
    }
}
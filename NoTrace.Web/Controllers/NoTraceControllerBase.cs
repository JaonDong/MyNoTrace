using Abp.Web.Mvc.Controllers;

namespace NoTrace.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class NoTraceControllerBase : AbpController
    {
        protected NoTraceControllerBase()
        {
            LocalizationSourceName = NoTraceConsts.LocalizationSourceName;
        }
    }
}
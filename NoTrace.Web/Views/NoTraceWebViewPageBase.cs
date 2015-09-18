using Abp.Web.Mvc.Views;

namespace NoTrace.Web.Views
{
    public abstract class NoTraceWebViewPageBase : NoTraceWebViewPageBase<dynamic>
    {

    }

    public abstract class NoTraceWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected NoTraceWebViewPageBase()
        {
            LocalizationSourceName = NoTraceConsts.LocalizationSourceName;
        }
    }
}
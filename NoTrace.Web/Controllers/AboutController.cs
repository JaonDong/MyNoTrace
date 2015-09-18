using System.Web.Mvc;

namespace NoTrace.Web.Controllers
{
    public class AboutController : NoTraceControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
using System.Web.Mvc;

namespace NoTrace.Web.Controllers
{
    public class HomeController : NoTraceControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Abp.Web.Mvc.Controllers.Results;
using Microsoft.Owin.Security;
using NoTrace.Users;
using UserLogin = NoTrace.Web.Models.UserLogin;


namespace NoTrace.Web.Controllers
{
    public class AccountController : NoTraceControllerBase
    {
        private readonly NoTraceUserManager _userManager;
        private IAuthenticationManager Authentication => HttpContext.GetOwinContext().Authentication;

        public AccountController(NoTraceUserManager userManager)
        {
            _userManager = userManager;
        }
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Login(UserLogin model)
        {


            return new AbpJsonResult(0);
        }
    }
}
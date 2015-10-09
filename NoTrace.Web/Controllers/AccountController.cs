using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Controllers.Results;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using NoTrace.Users;
using NoTrace.Users.Dtos;


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
        public async Task<JsonResult> Login(NoTrace.Web.Models.UserLogin model)
        {
            var result = await _userManager.LoginAsyn(model.UserName, model.Password);

            switch (result.ResultType)
            {
                    case NoTraceLoginResultType.Sucessed:
                    Authentication.SignOut();
                    Authentication.SignIn(new AuthenticationProperties { IsPersistent = false }, result.ClaimsIdentity);
                    ; break;
                    case NoTraceLoginResultType.Failed:
                    ;break;
            }

            return new AbpJsonResult(new { successed = result.ResultType==NoTraceLoginResultType.Sucessed });
        }

        public ActionResult Registered()
        {

            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Registered(UserDto  user)
        {
            var result = await _userManager.CreateAsync(new User() {UserName = user.UserName,Password = user.Password,EmailAddress = user.EmailAddress});

            if (result.Succeeded)
            {
                return new AbpJsonResult(new {sucessed = true});
            }
            return new AbpJsonResult(new {sucessed = false});
        }
    }
}
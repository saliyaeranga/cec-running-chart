using System.Web.Mvc;
using System.Web.Security;
using CECRunningChart.Services.User;
using CECRunningChart.Web.Helpers;
using CECRunningChart.Web.Models.User;

namespace CECRunningChart.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Private Members

        private readonly IUserService userService;

        #endregion

        #region Constructor

        public HomeController()
        {
            userService = new UserService();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                if (Session[SessionKeys.UserInfo] == null)
                {
                    FormsAuthentication.SignOut();
                    return View(new LogOnModel());
                }
                return RedirectToAction("manage");
            }

            return View(new LogOnModel());
        }

        [HttpPost]
        public ActionResult Index(LogOnModel model, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ReturnUrl = Request.QueryString["ReturnUrl"];

            var user = userService.ValidateUser(model.UserName, model.Password);
            if (user == null)
            {
                ViewBag.InvalidUsernameOrPassword = true;
                return View(model);
            }

            // Add logedin user to session
            var userInfo = ModelMapper.GetUserModel(user);
            Session[SessionKeys.UserInfo] = userInfo;
            FormsAuthentication.SetAuthCookie(userInfo.UserName, false);

            if (Url.IsLocalUrl(ReturnUrl) && ReturnUrl.Length > 1 && ReturnUrl.StartsWith("/")
                                    && !ReturnUrl.StartsWith("//") && !ReturnUrl.StartsWith("/\\"))
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction("manage", "home");
        }

        public ActionResult LogOff()
        {
            Session[SessionKeys.UserInfo] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Manage()
        {
            ViewBag.UserRole = (Session[SessionKeys.UserInfo] as UserModel).Role;
            return View();
        }

        #endregion
    }
}
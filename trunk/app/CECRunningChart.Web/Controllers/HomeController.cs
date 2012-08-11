using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CECRunningChart.Web.Models.User;
using CECRunningChart.Services.User;
using CECRunningChart.Web.Helpers;
using System.Web.Security;
using System.Security.Principal;
using CECRunningChart.Web.Common;

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
                return RedirectToAction("Manage");
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

            return RedirectToAction("Manage", "Home");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult innerPage()
        {
            return View();
        }
        public ActionResult subInnerPage()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult Manage()
        {
            return View();
        }
    }
}

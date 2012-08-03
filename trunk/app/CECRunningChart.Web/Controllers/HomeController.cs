using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CECRunningChart.Web.Models.User;
using CECRunningChart.Services.User;
using CECRunningChart.Web.Helpers;

namespace CECRunningChart.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        
        public HomeController()
        {
            userService = new UserService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new UserModel());
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = userService.ValidateUser(model.UserName, model.Password);
            if (user == null)
            {
                ViewBag.InvalidUsernameOrPassword = true;
                return View(model);
            }

            Session[SessionKeys.UserInfo] = ModelMapper.GetUserModel(user);
            return RedirectToAction("Manage", "Home");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }
    }
}

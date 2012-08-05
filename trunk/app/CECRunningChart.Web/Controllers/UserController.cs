using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CECRunningChart.Core;
using CECRunningChart.Services.User;
using CECRunningChart.Web.Helpers;
using CECRunningChart.Web.Models.User;

namespace CECRunningChart.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        #region Private Members

        private readonly IUserService userService;

        #endregion

        #region Constructor

        public UserController()
        {
            userService = new UserService();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<User> users = userService.GetAllUsers();
                var userModel = ModelMapper.GetUserModelList(users);
                return View(userModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                var user = userService.GetUser(id);
                UserModel model = ModelMapper.GetUserModel(user);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UserModel());
        } 

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = ModelMapper.GetUser(model);
                    userService.AddNewUser(user);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var user = userService.GetUser(id);
                UserModel model = ModelMapper.GetUserModel(user);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            try
            {
                var user = ModelMapper.GetUser(model);
                userService.UpdateUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Reset()
        {
            ViewBag.UserId = 1; //TODO : Authorize and get from session
            return View();
        } 

        [HttpPost]
        public ActionResult Reset(int id, string oldPassword, string newPassword, string confNewPassword)
        {
            try
            {
                bool status = userService.ResetPassword(id, oldPassword, newPassword);
                if (status)
                {
                    //return RedirectToAction("Manage", "Home");
                    return RedirectToAction("Reset");
                }
                ViewBag.UserId = 1; //TODO : Authorize and get from session
                ViewBag.Error = "Password can not be reset. Please make sure the old password is correct.";
                return View();
            }
            catch
            {
                throw;
            }
        } 

        #endregion
    }
}

using System;
using System.Web.Mvc;
using CECRunningChart.Web.Helpers;
using CECRunningChart.Web.Models.User;

namespace CECRunningChart.Web.Common
{
    public class CECAuthorize : ActionFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session[SessionKeys.UserInfo] == null || !filterContext.HttpContext.User.Identity.IsAuthenticated
                || string.IsNullOrWhiteSpace(Roles))
            {
                // User is not authenticated. Send him for authentication.
                filterContext.HttpContext.Response.Redirect("/Home/Index", true);
                return;
            }

            var userRole = (filterContext.HttpContext.Session[SessionKeys.UserInfo] as UserModel).RoleName;
            var userRoles = Roles.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            bool hasAccess = Array.IndexOf(userRoles, userRole) >= 0;
            if (!hasAccess)
            {
                // User is not authorized. Send him home page.
                filterContext.HttpContext.Response.Redirect("/Home/Index", true);
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
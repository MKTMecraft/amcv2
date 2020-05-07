using TodoDashboard.Common;
using TodoDashboard.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;

namespace TodoDashboard.Infrastructure
{
    public class BaseController : Controller
    {
        #region Fields
        public static string AdminUserName;
        public static string CheckType;
        public static string CheckLastDate;        
        #endregion       
        
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        private bool IsAllowed(string controllerName, string[] accessControllers)
        {
            foreach (string accessController in accessControllers)
            {
                if (accessController.ToLower() == controllerName)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                bool isAllow = false;

                HttpCookie reqCookie = Request.Cookies["ClientLogin"];
                if (reqCookie == null)
                {
                    filterContext.Result = new RedirectResult("~/Authentication/SignIn");
                    return;
                }

                AdminUserName = Convert.ToString(reqCookie["UserName"]);
                ProjectSession.AdminUserName = AdminUserName;

                ProjectSession.UserType = ConvertTo.Integer(reqCookie["UserType"]);


                if (ProjectSession.UserType == 1 &&
                    IsAllowed(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower(),
                    Pages.Controllers.Admin
                    ))
                {
                    isAllow = true;
                }
                else if (ProjectSession.UserType == 2 &&
                    IsAllowed(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower(),
                    Pages.Controllers.Managers
                    ))
                {
                    isAllow = true;
                }



                if (!isAllow)
                {
                    filterContext.Result = new RedirectResult("~/Authentication/SignIn");
                    return;
                }
                base.OnActionExecuting(filterContext);
                //if (ProjectSession.AdminRoleName == "Admin")
                //{
                //    isAllow = true;
                //}
                //else
                //{
                //    isAllow = false;
                //}
                //if (!isAllow)
                //{
                //    filterContext.Result = new RedirectResult("~/Authentication/SignIn");
                //    return;
                //}
                base.OnActionExecuting(filterContext);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

    }
}
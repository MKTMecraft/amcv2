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

        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //HttpCookie reqCookie = Request.Cookies["UserLogin"];
                //if (reqCookie == null)
                //{
                //    filterContext.Result = new RedirectResult("~/Authentication/SignIn");
                //    return;
                //}

                //AdminUserName = Convert.ToString(reqCookie["UserName"]);
                //ProjectSession.AdminUserName = AdminUserName;

                //bool isAllow = false;
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
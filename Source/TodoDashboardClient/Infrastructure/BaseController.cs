using TodoDashboard.Common;
using TodoDashboardClient.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;

namespace TodoDashboardClient.Infrastructure
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
                //    filterContext.Result = new RedirectResult("~/Account/LogIn");
                //    return;
                //}

                //AdminUserName = Convert.ToString(reqCookie["UserName"]);
                //ProjectSession.AdminUserName = AdminUserName;

                //CheckType = Convert.ToString(reqCookie["CheckType"]);
                //ProjectSession.CheckType = CheckType;

                //bool isAllow = false;
                //if (ProjectSession.AdminUserID == 0 && filterContext.ActionDescriptor.ActionName == Actions.LogIn)
                //{
                //    isAllow = true;
                //}
                //else if (ProjectSession.AdminUserID == 0 && filterContext.ActionDescriptor.ActionName == Actions.ForgotPassword)
                //{
                //    isAllow = true;
                //}
                //else if (ProjectSession.AdminUserID > 0)
                //{
                //    isAllow = true;
                //}
                //else
                //{
                //    isAllow = false;
                //}
                //if (!isAllow)
                //{
                //    filterContext.Result = new RedirectResult("~/Account/LogIn");
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
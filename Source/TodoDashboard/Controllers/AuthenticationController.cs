using TodoDashboard.Common;
using TodoDashboard.Entities.Contract;
using TodoDashboard.Entities.V1;
using TodoDashboard.Infrastructure;
using TodoDashboard.Pages;
using TodoDashboard.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static TodoDashboard.Infrastructure.Enums;

namespace TodoDashboard.Controllers
{
    public class AuthenticationController : Controller
    {
        #region Fields
        private readonly AbstractMasterUserService abstractMasterUserService;
        #endregion

        #region Ctor
        public AuthenticationController(AbstractMasterUserService abstractMasterUserService)
        {
            this.abstractMasterUserService = abstractMasterUserService;
        }
        #endregion

        #region Methods
        [HttpGet]
        [ActionName(Actions.SignIn)]
        public ActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        [ActionName(Actions.SignIn)]
        public JsonResult SignIn(string email, string password)
        {
            MasterUser tdd_Client = new MasterUser();
            tdd_Client.Email = email;
            tdd_Client.Password = password;
            
            SuccessResult<AbstractMasterUser> result = abstractMasterUserService.MasterUser_Login(tdd_Client);
            if (result != null && result.Code == 200 && result.Item != null)
            {
                Session.Clear();
                ProjectSession.AdminUserID = result.Item.Id;
                ProjectSession.UserName = result.Item.Name;
                ProjectSession.Email = result.Item.Email;
                ProjectSession.UserType = result.Item.UserType;

                if(ProjectSession.UserType == 1)
                {
                    ProjectSession.AdminRoleName = "Admin";
                }
                else if(ProjectSession.UserType == 2)
                {
                    ProjectSession.AdminRoleName = "Manager";
                }
                
                HttpCookie cookie = new HttpCookie("ClientLogin");
                cookie.Values.Add("Id", result.Item.Id.ToString());
                cookie.Values.Add("UserName", result.Item.Name.ToString());
                cookie.Values.Add("UserType", result.Item.UserType.ToString());
                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);
                result.Item = null;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        [AllowAnonymous]
        [ActionName(Actions.Logout)]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return RedirectToAction(Actions.SignIn, Pages.Controllers.Authentication);
        }

        //[HttpGet]
        //[ActionName(Actions.MyAccount)]
        //public ActionResult MyAccount()
        //{
        //    int SubAdminId = 0;
        //    if (!ProjectSession.IsSuperAdmin)
        //    {
        //        SubAdminId = ProjectSession.AdminUserID;
        //    }
        //    SuccessResult<AbstractUsers> result = usersService.Select(SubAdminId);
        //    if (TempData["openPopup"] != null)
        //        ViewBag.openPopup = TempData["openPopup"];

        //    return View(result.Item);
        //}

        //[HttpPost]
        //[ValidateInput(false)]
        //[ActionName(Actions.UpdateProfile)]
        //public ActionResult UpdateProfile(Users Users, IEnumerable<HttpPostedFileBase> files)
        //{
        //    try
        //    {
        //        var item = usersService.Select(ProjectSession.AdminUserID).Item;
        //        SuccessResult<AbstractUsers> result = usersService.InsertUpdateUsers(Users);
        //        if (result.Item != null && result.Code == 200)
        //        {
        //            HttpCookie reqCookie = Request.Cookies["SubAdminUserLogin"];
        //            reqCookie.Values["AdminUserName"] = result.Item.FirstName + " " + result.Item.LastName;
        //            reqCookie.Expires = DateTime.Now.AddHours(1);
        //            Response.Cookies.Add(reqCookie);
        //            ProjectSession.AdminUserName = result.Item.FirstName + " " + result.Item.LastName;
        //            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), result.Message);
        //            return RedirectToAction(Actions.Index, Pages.Controllers.Dashboard);
        //        }
        //        else
        //        {
        //            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.danger.ToString(), result.Message);
        //            return RedirectToAction(Actions.Index, Pages.Controllers.Dashboard);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.danger.ToString(), Messages.CommonErrorMessage);
        //        return RedirectToAction(Actions.Index, Pages.Controllers.Dashboard);
        //    }
        //}


        //[HttpPost]
        //[ActionName(Actions.AdminUserResetPassword)]
        //public ActionResult ResetPassword(Users Users)
        //{
        //    int SubAdminId = 0;
        //    if (!ProjectSession.IsSuperAdmin)
        //    {
        //        SubAdminId = ProjectSession.AdminUserID;
        //    }
        //    if (Users.Password != string.Empty && Users.Password != null && Users.Password != "")
        //    {
        //        var result = usersService.UserPasswordUpdate(Users);
        //    }

        //    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), Messages.PasswordReSet);

        //    return RedirectToAction(Actions.LogIn, Pages.Controllers.Authentication, new { suc = "Password Changed SuccessFully" });

        //}

        //[HttpGet]
        //public JsonResult getpassword(string enteredPassword = "")
        //{
        //    AbstractUsers obj = new Users();
        //    obj.Password = enteredPassword;
        //    if (!ProjectSession.IsSuperAdmin)
        //    {
        //        obj.Id = ProjectSession.AdminUserID;
        //    }
        //    var getUsers = usersService.Login(obj).Item;

        //    if (getUsers != null)
        //    {
        //        return Json("true", JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("false", JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[AllowAnonymous]
        //[ActionName(Actions.Logout)]
        //public ActionResult Logout()
        //{
        //    Session.Clear();
        //    Session.Abandon();

        //    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Cache.SetNoStore();
        //    return RedirectToAction(Actions.LogIn, Pages.Controllers.Authentication);
        //}

        //[HttpGet]
        //[ActionName(Actions.Reset)]
        //public ActionResult Reset(string Id = null)
        //{
        //    if (ProjectSession.SubAdminResetUserID > 0)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction(Actions.LogIn, Pages.Controllers.Authentication);
        //    }
        //}

        #endregion
    }
}
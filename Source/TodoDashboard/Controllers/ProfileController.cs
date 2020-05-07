using DataTables.Mvc;
using System;
using System.Web.Mvc;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Entities.Contract;
using TodoDashboard.Entities.V1;
using TodoDashboard.Infrastructure;
using TodoDashboard.Pages;
using TodoDashboard.Services.Contract;

namespace TodoDashboard.Controllers
{
    public class ProfileController : BaseController
    {
        #region Fields
        public readonly AbstractMasterUserService abstractMasterUserService;
        #endregion

        #region Ctor
        public ProfileController(AbstractMasterUserService abstractMasterUserService)
        {
            this.abstractMasterUserService = abstractMasterUserService;
        }
        #endregion

        #region Methods

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upsert(string oldPassword, string newPassword, string lastPassword)
        {
            SuccessResult<AbstractMasterUser> result = abstractMasterUserService.MasterUser_Id(ProjectSession.AdminUserID);
            if (result.Item.Password != oldPassword)
            {
                return Json("400", JsonRequestBehavior.AllowGet);
            }
            if (newPassword != lastPassword)
            {
                return Json("403", JsonRequestBehavior.AllowGet);
            }

            MasterUser tdd_Client = new MasterUser();
            tdd_Client.Id = ProjectSession.AdminUserID;
            tdd_Client.Password = newPassword;
            abstractMasterUserService.MasterUser_ChangePassword(tdd_Client);
            return Json("200", JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
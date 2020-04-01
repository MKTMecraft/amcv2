using DataTables.Mvc;
using System;
using System.Web.Mvc;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Entities.Contract;
using TodoDashboard.Infrastructure;
using TodoDashboard.Pages;
using TodoDashboard.Services.Contract;

namespace TodoDashboard.Controllers
{
    public class ProfileController : BaseController
    {
        #region Fields
        #endregion

        #region Ctor
        public ProfileController()
        {
            
        }
        #endregion

        #region Methods

        public ActionResult ChangePassword()
        {
            return View();
        }

        #endregion
    }
}
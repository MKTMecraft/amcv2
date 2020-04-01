using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    public class UsersController : BaseController
    {
        #region Fields
        
        #endregion

        #region Ctor
        public UsersController()
        {
        }
        #endregion

        #region Methods
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult BindData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                List<Tdd_Client> Tdd_Client = new List<Tdd_Client>();

                Tdd_Client tdd_Clients = new Tdd_Client();
                tdd_Clients.FirstName = "Devansh";
                tdd_Clients.LastName = "Desai";
                tdd_Clients.Email = "desaidevansh89@gmail.com";
                tdd_Clients.AddressLine1 = "*dDvnsh998";
                tdd_Clients.IsActive = true;
                Tdd_Client.Add(tdd_Clients);

                tdd_Clients = new Tdd_Client();
                tdd_Clients.FirstName = "Rushay";
                tdd_Clients.LastName = "Trivedi";
                tdd_Clients.Email = "rushaytrivedi@gmail.com";
                tdd_Clients.AddressLine1 = "rushVedi1997";
                tdd_Clients.IsActive = false;
                Tdd_Client.Add(tdd_Clients);

                tdd_Clients = new Tdd_Client();
                tdd_Clients.FirstName = "Hassan";
                tdd_Clients.LastName = "Mansuri";
                tdd_Clients.Email = "hassanmansuri@soboft.com";
                tdd_Clients.AddressLine1 = "mansurriHassan123";
                tdd_Clients.IsActive = true;
                Tdd_Client.Add(tdd_Clients);


                string search = requestModel.Search.Value;
                //var model = null;
                totalRecord = (int)3;
                filteredRecord = (int)3;

                return Json(new DataTablesResponse(requestModel.Draw, Tdd_Client, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogHelper.Log(ex);
                return Json(new object[] { null }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
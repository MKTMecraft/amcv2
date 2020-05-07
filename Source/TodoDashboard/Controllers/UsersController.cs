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
        public readonly AbstractMasterUserService abstractMasterUserService;
        #endregion

        #region Ctor
        public UsersController(AbstractMasterUserService abstractMasterUserService)
        {
            this.abstractMasterUserService = abstractMasterUserService;
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
                string search = Convert.ToString(requestModel.Search.Value);

                var model = abstractMasterUserService.MasterUser_All(pageParam, search, null);
                
                totalRecord = (int)model.TotalRecords;
                filteredRecord = (int)model.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogHelper.Log(ex);
                return Json(new object[] { null }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Upsert(int Id,string Name,string Email, string Password)
        {
            AbstractMasterUser abstractMasterUser = new MasterUser();
            abstractMasterUser.Id = Id;
            abstractMasterUser.Name = Name;
            abstractMasterUser.Email = Email;
            abstractMasterUser.Password = Password;
            SuccessResult<AbstractMasterUser> successResult = abstractMasterUserService.MasterUser_Upsert(abstractMasterUser);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string ids)
        {
            ids = ids.Substring(0, ids.Length - 1);
            string var_sql = "delete from MasterUser where Id in (" + ids + ")";
            try
            {
                SqlConnection con = new SqlConnection(Configurations.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(var_sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetById(int Id)
        {
            SuccessResult<AbstractMasterUser> successResult = abstractMasterUserService.MasterUser_Id(Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
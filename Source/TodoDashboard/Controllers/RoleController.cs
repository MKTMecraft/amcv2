using DataTables.Mvc;
using GlodCleaning.Common;
using GlodCleaning.Common.Paging;
using GlodCleaning.Infrastructure;
using GlodCleaning.Pages;
using System;
using System.Web.Mvc;
using static GlodCleaning.Infrastructure.Enums;

namespace GlodCleaning.Controllers
{
    public class RoleController : BaseController
    {
        #region Fields
        private readonly AbstractExpenseTypesServices expenseTypesServices;
        #endregion

        #region Constructor
        public RoleController(AbstractExpenseTypesServices expenseTypesServices)
        {
            this.expenseTypesServices = expenseTypesServices;
        }
        #endregion

        // GET: Admin/States
        public ActionResult Index()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ExpenseTypeBind([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string search = requestModel.Search.Value;

                var model = expenseTypesServices.ExpenseTypeAll(pageParam,search);
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

        [HttpGet]
        public ActionResult Manage(string Id = null)
        {
            int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(Id));
            AbstractExpenseTypes objModel = null;
            if (decryptedId > 0)
            {
                objModel = expenseTypesServices.ExpenseTypeById(decryptedId,ProjectSession.CurrentCultureCode).Item;
            }
            return View(objModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.ExpenseTypeAddEdit)]
        public ActionResult ExpenseTypeAddEdit(ExpenseTypes expenseTypes)
        {
            SuccessResult<AbstractExpenseTypes> result = null;
            if (expenseTypes.Id == 0)
            {
                expenseTypes.CreatedBy = ProjectSession.AdminUserID;
            }
            else
            {
                expenseTypes.ModifiedBy = ProjectSession.AdminUserID;
            }
            //**** Insert or Update the States ****
            try
            {
                result = expenseTypesServices.ExpenseTypeUpsert(expenseTypes,ProjectSession.CurrentCultureCode);
                if (result.Code == 200 && result.Item != null)
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), result.Message);
                }
                else
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), result.Message);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), ex.Message);
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.ExpenseTypeDelete)]
        public ActionResult ExpenseTypeDelete(int Id)
        {
            try
            {
                int UserId = ProjectSession.AdminUserID;
                bool result = expenseTypesServices.ExpenseTypeDelete(Id, UserId);
                if (result)
                {
                    return Json(new object[] { Enums.MessageType.success.GetHashCode(), Enums.MessageType.success.ToString(), Messages.RecordDeletedSuccessfully }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), Messages.RecordNotDeleted }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), Messages.ContactToAdmin }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
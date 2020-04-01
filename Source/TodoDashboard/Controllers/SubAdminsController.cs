using DataTables.Mvc;
using GlodCleaning.Common;
using GlodCleaning.Common.Paging;
using GlodCleaning.Entities.Contract.Master;
using GlodCleaning.Entities.Contract.SubAdmin;
using GlodCleaning.Entities.V1.SubAdmin;
using GlodCleaning.Infrastructure;
using GlodCleaning.Pages;
using GlodCleaning.Services.Contract.Master;
using GlodCleaning.Services.Contract.SubAdmin;
using GlodCleaning.Services.V1.SubAdmin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static GlodCleaning.Infrastructure.Enums;

namespace GlodCleaning.Controllers
{
    public class SubAdminsController : BaseController
    {
        #region Fields
        private readonly AbstractDepartmentsServices abstractDepartmentsServices;
        private readonly AbstractSubAdminsServices abstractSubAdminsServices;
        private readonly AbstractDesignationsServices abstractDesignationsServices;
        private readonly AbstractTargetsServices abstractTargetsServices;
        private readonly AbstractStaffTargetsServices abstractStaffTargetsServices;
        private readonly AbstractStatesServices statesServices;
        private readonly AbstractDistrictsServices districtsServices;
        private readonly AbstractTalukaServices TalukasServices;
        #endregion

        #region Ctor
        public SubAdminsController(AbstractDepartmentsServices _abstractDepartmentsServices
            , AbstractSubAdminsServices _abstractSubAdminsServices
            , AbstractDesignationsServices _abstractDesignationsServices, AbstractTargetsServices _abstractTargetsServices,
            AbstractStaffTargetsServices _abstractStaffTargetsServices,
            AbstractStatesServices statesServices,
            AbstractDistrictsServices districtsServices,
            AbstractTalukaServices TalukasServices)
        {
            this.abstractDepartmentsServices = _abstractDepartmentsServices;
            this.abstractSubAdminsServices = _abstractSubAdminsServices;
            this.abstractDesignationsServices = _abstractDesignationsServices;
            this.abstractTargetsServices = _abstractTargetsServices;
            this.abstractStaffTargetsServices = _abstractStaffTargetsServices;
            this.statesServices = statesServices;
            this.districtsServices = districtsServices;
            this.TalukasServices = TalukasServices;
        }
        #endregion

        [ActionName(Actions.Index)]
        public ActionResult Index(string designation = "MA==", string requestedSubAdmin = "MA==", string department = "MA==")
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];

            if (designation == "MA==")
            {
                designation = ProjectSession.DesignationId;
            }

            if (requestedSubAdmin == "MA==")
            {
                requestedSubAdmin = ConvertTo.Base64Encode(ProjectSession.AdminUserID.ToString());
            }

            if (department == "MA==")
            {
                department = ProjectSession.DepartmentId;
            }

            var requestSubAdminData = abstractSubAdminsServices.SubAdminById(Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)), ProjectSession.CurrentCultureCode).Item;

            var requestSubAdmin = abstractSubAdminsServices.SubAdminById(ProjectSession.AdminUserID, ProjectSession.CurrentCultureCode).Item;

            ViewBag.CanAddSubordinates = requestSubAdmin.CanAddSubordinates;
            ViewBag.RequesteSubAdminName = requestSubAdminData.FirstName;
            ViewBag.CanAddAggregator = requestSubAdminData.IsTarget;
            ViewBag.DesignationId = designation;
            ViewBag.DepartmentId = department;
            ViewBag.RequestedSubAdminId = requestedSubAdmin;

            if ((ProjectSession.IsSuperAdmin && (Convert.ToInt32(ConvertTo.Base64Decode(designation)) != 0)) || (ProjectSession.DesignationName == "Controller" && (Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)) != ProjectSession.AdminUserID)))
            {
                ViewBag.BreadCrums = abstractSubAdminsServices.SubAdminHierarchicalPathForSuperAdmin(Convert.ToInt32(ConvertTo.Base64Decode(designation)), Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)));
            }
            else if (designation != "MA==")
            {
                ViewBag.subAdminPath = abstractSubAdminsServices.SubAdminHeirarchialPath(Convert.ToInt32(ConvertTo.Base64Decode(designation)), Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)));
                ViewBag.DesignationName = abstractDesignationsServices.DesignationById(Convert.ToInt32(ConvertTo.Base64Decode(designation)),ProjectSession.CurrentCultureCode).Item.Name;
                ViewBag.BreadCrums = abstractSubAdminsServices.SubAdminHeirarchialPath(Convert.ToInt32(ConvertTo.Base64Decode(designation)), Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)));
            }            
            //if (ViewBag.BreadCrums == null)
            //{
            //    ViewBag.BreadCrums = requestSubAdminData.FirstName + " " + requestSubAdminData.LastName + "," + ViewBag.DesignationName + "," + Convert.ToInt32(ConvertTo.Base64Decode(designation)) + "," + Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)) + "|";
            //}
            //var initialSubAdminData = abstractSubAdminsServices.SubAdminById(Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin))).Item;

            return View();
        }

        // GET: SubAdmin/ToDos
        public ActionResult Target(string requestedSubAdmin = "MA==")
        {
            int SubAdminId = ProjectSession.AdminUserID;
            SuccessResult<AbstractSubAdmins> successResult = null;
            if (requestedSubAdmin == "MA==")
            {
                requestedSubAdmin = ConvertTo.Base64Encode(ProjectSession.AdminUserID.ToString());
                ViewBag.IsTab = 0;
            }
            else
            {
                ViewBag.IsTab = 1;
            }
            int requestedSubadminId = Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin));
            successResult = abstractSubAdminsServices.SubAdminById(requestedSubadminId, ProjectSession.CurrentCultureCode);
            if (successResult.Item != null)
            {
                if ((ProjectSession.IsSuperAdmin && successResult.Item.DesignationId != 0) || (ProjectSession.DesignationName == "Controller" && (Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)) != ProjectSession.AdminUserID)))
                {
                    ViewBag.BreadCrums = abstractSubAdminsServices.SubAdminHierarchicalPathForSuperAdmin(successResult.Item.DesignationId, Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)));
                }
                else if (successResult.Item.DesignationId != 0)
                {
                    ViewBag.BreadCrums = abstractSubAdminsServices.SubAdminHeirarchialPath(successResult.Item.DesignationId, Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)));
                }

            }
            ViewBag.RequestedSubAdminId = requestedSubAdmin;
            var subadminDetails = abstractSubAdminsServices.SubAdminById(Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)), ProjectSession.CurrentCultureCode).Item;
            ViewBag.DesignationName = subadminDetails.DesignationName;
            ViewBag.DesignationId = ConvertTo.Base64Encode(subadminDetails.DesignationId.ToString());
            ViewBag.RequesteSubAdminName = subadminDetails.FirstName;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindSubAdmin)]
        public JsonResult BindSubAdmin([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string designation = "MA==", string RequestedSubAdminId = "MA==")
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                int designationid = 0;
                int requestedSubAdminId = 0;

                designationid = Convert.ToInt32(ConvertTo.Base64Decode(designation));
                requestedSubAdminId = Convert.ToInt32(ConvertTo.Base64Decode(RequestedSubAdminId));

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string Search = requestModel.Search.Value;

                PagedList<AbstractSubAdmins> subAdmins = new PagedList<AbstractSubAdmins>();

                if (requestedSubAdminId == ProjectSession.AdminUserID
                    && (Convert.ToInt32(ConvertTo.Base64Decode(ProjectSession.DepartmentId)) == 1 || ProjectSession.IsSuperAdmin))
                {
                    subAdmins = abstractSubAdminsServices.GetSubAdminForAdmin(pageParam, Search);
                }                
                else
                {
                    subAdmins = abstractSubAdminsServices.SubAdminByDepartment(pageParam, designationid, ProjectSession.AdminUserID, requestedSubAdminId, Search);
                }

                foreach (var item in subAdmins.Values)
                {
                    if (item.AvtarPath != null && item.AvtarPath != "")
                    {
                        item.AvtarPath = abstractSubAdminsServices.GeneratePreSignedURL(item.AvtarPath);
                    }
                }

                totalRecord = (int)subAdmins.TotalRecords;
                filteredRecord = (int)subAdmins.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, subAdmins.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), Messages.CommonErrorMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindTargets)]
        public JsonResult BindTargets([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, int TargetId = 0, string StartDate = null)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                var model = abstractStaffTargetsServices.GenerateStaffTargetsByTargetId(TargetId, StartDate);

                foreach (var item in model.Values)
                {
                    model.Values.FirstOrDefault().TotalTarget += item.Target;
                }

                totalRecord = (int)model.TotalRecords;
                filteredRecord = (int)model.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), Messages.CommonErrorMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindTargetsBySubAdmin)]
        public JsonResult BindTargetsBySubAdmin([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string subAdmin = "MA==")
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string Search = requestModel.Search.Value;
                int subadminId = 0;
                subadminId = Convert.ToInt32(ConvertTo.Base64Decode(subAdmin));

                var model = abstractStaffTargetsServices.StaffTargetsBySubAdminId(pageParam, subadminId, Search);

                totalRecord = (int)model.TotalRecords;
                filteredRecord = (int)model.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), Messages.CommonErrorMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: SubAdmin/Attendance
        public ActionResult SubAdminDetail(string subAdmin = "MA==", string designation = "MA==", string requestedSubAdmin = "MA==", string department = "MA==")
        {
            AbstractSubAdmins abstractSubAdmins = new Users();
            try
            {
                var CanAllowRequestedSubAdmin = abstractSubAdminsServices.SubAdminById(Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)), ProjectSession.CurrentCultureCode).Item;
                if (CanAllowRequestedSubAdmin.CanAddAggregators)
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), "Cannot Add Sub Admins as " + CanAllowRequestedSubAdmin.FirstName + " " + CanAllowRequestedSubAdmin.LastName + " ( " + CanAllowRequestedSubAdmin.DepartmentName + ") does not have the rights");
                    return RedirectToAction(Actions.Index, Pages.Controllers.Users, new { designation = designation, requestedSubAdmin = requestedSubAdmin });
                }

                int id = Convert.ToInt32(ConvertTo.Base64Decode(subAdmin));

                if (id > 0)
                {
                    abstractSubAdmins = abstractSubAdminsServices.SubAdminById(id, ProjectSession.CurrentCultureCode).Item;
                }


                abstractSubAdmins.PreviousDesignationId = Convert.ToInt32(ConvertTo.Base64Decode(designation));
                abstractSubAdmins.RequestedSubAdminId = Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin));

                if (id == 0 && abstractSubAdmins.RequestedSubAdminId > 0)
                {
                    var subAdmins = abstractSubAdminsServices.SubAdminById(abstractSubAdmins.RequestedSubAdminId.Value, ProjectSession.CurrentCultureCode).Item;
                    abstractSubAdmins.ReportingToName = subAdmins.FirstName + ' ' + subAdmins.LastName;
                    abstractSubAdmins.ReportingTo = subAdmins.ReportingTo;

                }

                int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(designation));
                if (decryptedId == 1)
                {
                }
                else
                {
                }

                int departmentId = Convert.ToInt32(ConvertTo.Base64Decode(department));
                ViewBag.DepartmentId = departmentId;
                if (departmentId == 1)
                {
                }
                else
                {
                    abstractSubAdmins.DepartmentId = departmentId;
                }

                return View(abstractSubAdmins);
            }
            catch (Exception ex)
            {
                return View(abstractSubAdmins);
            }
        }

        [HttpGet]
        [ActionName(Actions.Manage)]
        public ActionResult Manage(string subAdmin = "MA==", string designation = "MA==", string requestedSubAdmin = "MA==", string department = "MA==")
        {
            AbstractSubAdmins abstractSubAdmins = new Users();
            AbstractSubAdmins objParentStateDistrictTaluka = new Users();
            try
            {
                var CanAllowRequestedSubAdmin = abstractSubAdminsServices.SubAdminById(Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin)), ProjectSession.CurrentCultureCode).Item;
                if (CanAllowRequestedSubAdmin.CanAddAggregators)
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), "Cannot Add Sub Admins as " + CanAllowRequestedSubAdmin.FirstName + " " + CanAllowRequestedSubAdmin.LastName + " ( " + CanAllowRequestedSubAdmin.DepartmentName + ") does not have the rights");
                    return RedirectToAction(Actions.Index, Pages.Controllers.Users, new { designation = designation, requestedSubAdmin = requestedSubAdmin });
                }

                int id = Convert.ToInt32(ConvertTo.Base64Decode(subAdmin));
                if (id > 0)
                {
                    abstractSubAdmins = abstractSubAdminsServices.SubAdminById(id, ProjectSession.CurrentCultureCode).Item;
                    abstractSubAdmins.DocumentAvtarPath = Configurations.S3ImageUrl + abstractSubAdmins.AvtarPath;

                }
                else
                {
                    objParentStateDistrictTaluka = abstractSubAdminsServices.GetParentDistrictAndTalukaBySubAdminId(Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin))).Item;
                    abstractSubAdmins.StateId = objParentStateDistrictTaluka.ParentStateId;
                    abstractSubAdmins.DistrictId = objParentStateDistrictTaluka.ParentDistrictId;
                    abstractSubAdmins.TalukaId = objParentStateDistrictTaluka.ParentTalukaId;

                }

                abstractSubAdmins.PreviousDesignationId = Convert.ToInt32(ConvertTo.Base64Decode(designation));
                abstractSubAdmins.RequestedSubAdminId = Convert.ToInt32(ConvertTo.Base64Decode(requestedSubAdmin));
                

                if (id == 0 && abstractSubAdmins.RequestedSubAdminId > 0)
                {
                    var subAdmins = abstractSubAdminsServices.SubAdminById(abstractSubAdmins.RequestedSubAdminId.Value, ProjectSession.CurrentCultureCode).Item;
                    abstractSubAdmins.ReportingToName = subAdmins.FirstName + ' ' + subAdmins.LastName;
                }

                int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(designation));
                ViewBag.DesigantionId = decryptedId;

                if (decryptedId == 1 || ProjectSession.IsSuperAdmin)
                {
                }
                else
                {
                }

                int departmentId = Convert.ToInt32(ConvertTo.Base64Decode(department));
                ViewBag.DepartmentId = departmentId;
                if (departmentId == 1 || ProjectSession.IsSuperAdmin)
                {
                }
                else
                {
                    abstractSubAdmins.DepartmentId = departmentId;
                }

                if (abstractSubAdmins.RequestedSubAdminId == ProjectSession.AdminUserID
                    && Convert.ToInt32(ConvertTo.Base64Decode(ProjectSession.DepartmentId)) == 1)
                {
                    abstractSubAdmins.ReportingTo = null;
                    abstractSubAdmins.ReportingToName = null;
                }

                return View(abstractSubAdmins);
            }
            catch (Exception ex)
            {
                return View(abstractSubAdmins);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        [ActionName(Actions.AddEditSubAdmin)]
        public ActionResult AddEditSubAdmin(Users subAdmins, IEnumerable<HttpPostedFileBase> userProfile)
        {
            int Id = 0;
            if (subAdmins.Id == 0)
            {
                subAdmins.Password = "123";
            }
            try
            {
                subAdmins.ReferenceCode = GenerateRandomNo().ToString();
                if (subAdmins.RequestedSubAdminId == ProjectSession.AdminUserID
                    && Convert.ToInt32(ConvertTo.Base64Decode(ProjectSession.DepartmentId)) == 1)
                {
                    subAdmins.RequestedSubAdminId = null;
                }
                SuccessResult<AbstractSubAdmins> result = abstractSubAdminsServices.SubAdminUpsert(subAdmins, userProfile);
                if (result.Item != null && result.Code == 200)
                {
                    if (subAdmins.Id == 0)
                    {
                        //Send Welcome Mail
                        if (result.Item.Email != "")
                        {
                            string body = string.Empty;

                            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate/Reg.html")))
                            {
                                body = reader.ReadToEnd();
                            }
                            string Fullname = result.Item.FirstName + " " + result.Item.LastName;
                            body = body.Replace("#CustomerName#", Fullname);
                            body = body.Replace("#CustomerEmail#", result.Item.Email);
                            body = body.Replace("#CustomerPassword#", result.Item.Password);
                            body = body.Replace("#LoginURL#", Configurations.ClientLoginURL);
                            EmailHelper.Send(result.Item.Email, "", "", "Welcome To KeviMart", body);
                        }
                        if (result.Item.ContactNumber != "")
                        {
                            string message = "તમારા કેવી માર્ટ એકાઉન્ટને ઍક્સેસ કરવા માટે કૃપા કરીને નીચે આપેલ લિંક નો ઉપયોગ કરો અને તમારા મોબાઇલ નંબરનો તમારા વપરાશકર્તા નામ તરીકે ઉપયોગ કરો." + Environment.NewLine + "UserName: #gmail#" + Environment.NewLine + "Password: #password#" + Environment.NewLine + "LoginUrl: #url#" + Environment.NewLine + "AndroidApp: #Android#" + Environment.NewLine + "IOSApp: #Ios#";
                            message = message.Replace("#gmail#", result.Item.Email);
                            message = message.Replace("#password#", result.Item.Password);
                            message = message.Replace("#url#", Configurations.ClientLoginURL);
                            message = message.Replace("#Android#", Configurations.AndroidUrl);
                            message = message.Replace("#Ios#", Configurations.IosUrl);
                            SmsHelper.Send(result.Item.ContactNumber, "", message);
                        }
                    }
                    Id = result.Item.Id;
                    //if (subAdmins.TargetId != 0 && !string.IsNullOrWhiteSpace(subAdmins.StartDate))
                    //{
                    string Lang = ProjectSession.CurrentCultureCode;
                    var model = abstractStaffTargetsServices.StaffTargetsUpsert(Id, subAdmins.TargetId, subAdmins.StartDate,Lang);
                    //}
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), result.Message);
                }
                else if(result.Code == 403)
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), result.Message);
                }
                else
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), result.Message);
                }
                return RedirectToAction(Actions.Index, new { designation = ConvertTo.Base64Encode(subAdmins.PreviousDesignationId.ToString()), RequestedSubAdmin = ConvertTo.Base64Encode(subAdmins.RequestedSubAdminId.ToString()), department = ConvertTo.Base64Encode(subAdmins.DepartmentId.ToString()) });
            }
            catch (Exception ex)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), ex.Message);
                return RedirectToAction(Actions.Index, new { designation = ConvertTo.Base64Encode(subAdmins.PreviousDesignationId.ToString()), RequestedSubAdmin = ConvertTo.Base64Encode(subAdmins.RequestedSubAdminId.ToString()), department = ConvertTo.Base64Encode(subAdmins.DepartmentId.ToString()) });
            }
        }

        [HttpPost]
        [ActionName(Actions.SubAdminById)]
        public JsonResult SubAdminById(string Id = "MA==")
        {
            AbstractSubAdmins abstractSubAdmins = new Users();
            int id = Convert.ToInt32(Id);

            if (id > 0)
            {
                abstractSubAdmins = abstractSubAdminsServices.SubAdminById(id, ProjectSession.CurrentCultureCode).Item;
                if (abstractSubAdmins.AvtarPath != null)
                {
                    abstractSubAdmins.AvtarPath = Configurations.S3ImageUrl + abstractSubAdmins.AvtarPath;
                }
            }

            return Json(abstractSubAdmins, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName(Actions.ChangeStatus)]
        public JsonResult ChangeStatus(string Id = "MA==", bool Status = true)
        {
            AbstractSubAdmins abstractSubAdmins = new Users();
            int id = Convert.ToInt32(ConvertTo.Base64Decode(Id));

            if (id > 0)
            {
                abstractSubAdmins = abstractSubAdminsServices.SubAdminUpdateStatus(id,Status,ProjectSession.CurrentCultureCode).Item;
            }

            return Json(abstractSubAdmins, JsonRequestBehavior.AllowGet);
        }

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
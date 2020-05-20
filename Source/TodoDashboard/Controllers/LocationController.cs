using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public class LocationController : BaseController
    {
        #region Fields
        public readonly AbstractMasterLocationsService abstractMasterLocationsService;
        public readonly AbstractMasterWinesService abstractMasterWinesService;
        private readonly AbstractMasterWineVaritalsService abstractMasterWineVaritalsService;
        private readonly AbstractMasterBarTypesService abstractMasterBarTypesService;
        private readonly AbstractMasterServicesTypesService abstractMasterServicesTypesService;
        private readonly AbstractMasterTiersService abstractMasterTiersService;
        private readonly AbstractMasterDistributorsService abstractMasterDistributorsService;
        private readonly AbstractMasterStatesService abstractMasterStatesService;
        #endregion

        #region Ctor
        public LocationController(AbstractMasterLocationsService abstractMasterLocationsService, AbstractMasterWinesService abstractMasterWinesService,
            AbstractMasterWineVaritalsService abstractMasterWineVaritalsService, AbstractMasterBarTypesService abstractMasterBarTypesService
            , AbstractMasterServicesTypesService abstractMasterServicesTypesService, AbstractMasterTiersService abstractMasterTiersService,
            AbstractMasterDistributorsService abstractMasterDistributorsService, AbstractMasterStatesService abstractMasterStatesService)
        {
            this.abstractMasterLocationsService = abstractMasterLocationsService;
            this.abstractMasterWinesService = abstractMasterWinesService;
            this.abstractMasterWineVaritalsService = abstractMasterWineVaritalsService;
            this.abstractMasterBarTypesService = abstractMasterBarTypesService;
            this.abstractMasterServicesTypesService = abstractMasterServicesTypesService;
            this.abstractMasterTiersService = abstractMasterTiersService;
            this.abstractMasterDistributorsService = abstractMasterDistributorsService;
            this.abstractMasterStatesService = abstractMasterStatesService;
        }
        #endregion

        #region Methods
        public ActionResult Index(int Id=0)
        {
            ViewBag.States = BindDropDowns("states");
            ViewBag.ServiceTypes = BindDropDowns("servicetypes");
            ViewBag.BarTypes = BindDropDowns("bartypes");
            //ViewBag.WineVaritals = BindDropDowns("winevaritals");
            //ViewBag.Distributors = BindDropDowns("distributors");
            //ViewBag.Tiers = BindDropDowns("tiers");
            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult BindWineData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,int LocationId = 0)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                int count = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                AbstractMasterWines abstractMasterWines = new MasterWines();

                var model = abstractMasterWinesService.MasterWines_All(pageParam, search, abstractMasterWines,LocationId);
                //List<LocationWines> selectedWines = new List<LocationWines>();
                //selectedWines = GetCheckedWines(LocationId);

                //if(selectedWines.Count > 0 && LocationId > 0)
                //{
                //    model.Values = model.Values
                //    foreach (var data in model.Values)
                //    {
                //        //LocationWines locationWines = new LocationWines();
                //        //locationWines.MasterWineId = data.Id;
                //        if (selectedWines.Find(x => x.MasterWineId == data.Id) != null && selectedWines.Find(x => x.MasterWineId == data.Id).MasterWineId != 0)
                //        {
                //            //data.IsChecked = true;
                //        }
                //        else
                //        {
                //            //data.IsChecked = false;
                //            model.Values.RemoveAt(count);
                //        }

                //        count++;
                //    }
                //    model.TotalRecords = model.Values.Count;                    
                //}
               
                filteredRecord = (int)model.TotalRecords;
                totalRecord = (int)model.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogHelper.Log(ex);
                return Json(new object[] { null }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Upsert(int Id,string LocationId, string LocationName, int StateId, int ServiceTypeId, int  BarTypeId,string WineIds="")
        {
           
            AbstractMasterLocations abstractMasterLocations = new MasterLocations();
            abstractMasterLocations.Id = Id;
            abstractMasterLocations.LocationId = LocationId;
            abstractMasterLocations.LocationName = LocationName;
            abstractMasterLocations.StateId = StateId;
            abstractMasterLocations.ServiceTypeId = ServiceTypeId;
            abstractMasterLocations.BarTypeId = BarTypeId;

            SuccessResult<AbstractMasterLocations> result = abstractMasterLocationsService.MasterLocations_Upsert(abstractMasterLocations);

            try
            {
                if(Id == 0 && result != null && result.Code == 200 && result.Item != null && WineIds != null && WineIds != "")
                {
                    WineIds = WineIds.Substring(0, WineIds.Length - 1);
                    InsertLocationWines(WineIds, result.Item.Id);
                }
                else if(Id == 0 && result != null && result.Code == 200 && result.Item != null)
                {
                    InsertLocationWines(WineIds, result.Item.Id);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteSelectedWinesFromLocation(int LocationId, string WineIds = "")
        {
            if(LocationId > 0 && WineIds != string.Empty && WineIds != null && WineIds != "")
            {
                WineIds = WineIds.Substring(0, WineIds.Length - 1);
                DeleteSelectedWines(LocationId, WineIds);
                return Json("200", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("400", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetById(int Id)
        {
            SuccessResult<AbstractMasterLocations> successResult = abstractMasterLocationsService.MasterLocations_Id(Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        public List<LocationWines> GetCheckedWines(int LocationId)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Configurations.ConnectionString);
            string var_sql = "select MasterWineId from LocationWines where MasterLocationId=" + LocationId;
            SqlDataAdapter sda = new SqlDataAdapter(var_sql, con);
            sda.Fill(dt);
            return CommonHelper.ConvertDataTable<LocationWines>(dt);
        }

        public void InsertLocationWines(string WineIds,int LocationId)
        {
            SqlConnection con = new SqlConnection(Configurations.ConnectionString);
            string var_sql = "delete from LocationWines where MasterLocationId=" + LocationId;
            SqlCommand cmd = new SqlCommand(var_sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            if(WineIds != "")
            {
                var_sql = "insert into LocationWines (MasterLocationId,MasterWineId) values ";
                string[] wineId = WineIds.Split(',');
                for (int start = 0; start < wineId.Length; start++)
                {
                    if (start == 0)
                    {
                        var_sql += "(" + LocationId + "," + wineId[start] + ")";
                    }
                    else
                    {
                        var_sql += ",(" + LocationId + "," + wineId[start] + ")";
                    }
                }

                cmd = new SqlCommand(var_sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IList<SelectListItem> BindDropDowns(string action = "")
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                PageParam pageParam = new PageParam();
                pageParam.Offset = 0;
                pageParam.Limit = 0;

                if (action == "winevaritals")
                {
                    var model = abstractMasterWineVaritalsService.MasterWineVaritals_All(pageParam, "");
                    foreach (var master in model.Values)
                    {
                        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
                    }
                }
                else if (action == "bartypes")
                {
                    var model = abstractMasterBarTypesService.MasterBarTypes_All(pageParam, "");
                    foreach (var master in model.Values)
                    {
                        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
                    }
                }
                else if (action == "servicetypes")
                {
                    var model = abstractMasterServicesTypesService.MasterServicesTypes_All(pageParam, "");
                    foreach (var master in model.Values)
                    {
                        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
                    }
                }
                else if (action == "tiers")
                {
                    var model = abstractMasterTiersService.MasterTiers_All(pageParam, "");
                    foreach (var master in model.Values)
                    {
                        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
                    }
                }
                else if (action == "distributors")
                {
                    var model = abstractMasterDistributorsService.MasterDistributors_All(pageParam, "");
                    foreach (var master in model.Values)
                    {
                        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
                    }
                }
                else if (action == "states")
                {
                    var model = abstractMasterStatesService.MasterStates_All(pageParam, "");
                    foreach (var master in model.Values)
                    {
                        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                return items;
            }
        }

        public void DeleteSelectedWines(int LocationId, string WineIds = "")
        {
            string var_sql = "delete from LocationWines where MasterLocationId=" + LocationId + " and MasterWineId in ("+WineIds+")";
            SqlConnection con = new SqlConnection(Configurations.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(var_sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult Delete(int ids)
        {
            string var_sql = "";
            var_sql = "delete from MasterLocations where Id=" + ids;
          
            try
            {
                SqlConnection con = new SqlConnection(Configurations.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(var_sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                var_sql = "delete from LocationWines where MasterLocationId=" + ids;
                con.Open();
                cmd = new SqlCommand(var_sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
        public class LocationWines
        {
            public int MasterWineId { get; set; }
        }
    }
}
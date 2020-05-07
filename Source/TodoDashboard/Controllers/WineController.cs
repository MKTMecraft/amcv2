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
    public class WineController : BaseController
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
        public WineController(AbstractMasterLocationsService abstractMasterLocationsService, AbstractMasterWinesService abstractMasterWinesService,
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
        public ActionResult Index(int Id = 0)
        {
            ViewBag.WineVaritals = BindDropDowns("winevaritals");
            ViewBag.Distributors = BindDropDowns("distributors");
            ViewBag.Tiers = BindDropDowns("tiers");
            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult BindLocationData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, int WineId = 0)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                AbstractMasterLocations abstractMasterLocations = new MasterLocations();
                

                var model = abstractMasterLocationsService.MasterLocations_All(pageParam, search, abstractMasterLocations,WineId);
                //List<LocationWines> selectedWines = new List<LocationWines>();
                //selectedWines = GetCheckedWines(WineId);

                //if (selectedWines.Count > 0)
                //{
                //    foreach (var data in model.Values)
                //    {
                //        LocationWines locationWines = new LocationWines();
                //        locationWines.MasterLocationId = data.Id;
                //        if (selectedWines.Find(x => x.MasterLocationId == data.Id) != null && selectedWines.Find(x => x.MasterLocationId == data.Id).MasterLocationId != 0)
                //        {
                //            data.IsChecked = true;
                //        }
                //        else
                //        {
                //            data.IsChecked = false;
                //        }
                //    }
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
        public JsonResult Upsert(int Id, string WineName,int MasterVarietalId, string Calories, int MasterDistributorId, int TierId,string LocationIds="")
        {
            AbstractMasterWines abstractMasterWines = new MasterWines();
            abstractMasterWines.Id = Id;
            abstractMasterWines.WineName = WineName;
            abstractMasterWines.MasterVarietalId = MasterVarietalId;
            abstractMasterWines.Calories = Calories;
            abstractMasterWines.MasterDistributorId = MasterDistributorId;
            abstractMasterWines.TierId = TierId;

            SuccessResult<AbstractMasterWines> result = abstractMasterWinesService.MasterWines_Upsert(abstractMasterWines);

            try
            {
                if (Id == 0 && result != null && result.Code == 200 && result.Item != null && LocationIds != null && LocationIds != "")
                {
                    LocationIds = LocationIds.Substring(0, LocationIds.Length - 1);
                    InsertLocationWines(LocationIds, result.Item.Id);
                }
                else if (Id == 0 && result != null && result.Code == 200 && result.Item != null)
                {
                    InsertLocationWines(LocationIds, result.Item.Id);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteSelectedLocationsFromWine(int WineId, string LocationIds = "")
        {
            if (WineId > 0 && LocationIds != string.Empty && LocationIds != null && LocationIds != "")
            {
                LocationIds = LocationIds.Substring(0, LocationIds.Length - 1);
                DeleteSelectedLocations(WineId, LocationIds);
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
            SuccessResult<AbstractMasterWines> successResult = abstractMasterWinesService.MasterWines_Id(Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        public List<LocationWines> GetCheckedWines(int WineId)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Configurations.ConnectionString);
            string var_sql = "select MasterLocationId from LocationWines where MasterWineId=" + WineId;
            SqlDataAdapter sda = new SqlDataAdapter(var_sql, con);
            sda.Fill(dt);
            return CommonHelper.ConvertDataTable<LocationWines>(dt);
        }

        public void InsertLocationWines(string LocationIds, int WineId)
        {
            SqlConnection con = new SqlConnection(Configurations.ConnectionString);
            string var_sql = "delete from LocationWines where MasterWineId=" + WineId;
            SqlCommand cmd = new SqlCommand(var_sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            if (LocationIds != "")
            {
                var_sql = "insert into LocationWines (MasterWineId,MasterLocationId) values ";
                string[] wineId = LocationIds.Split(',');
                for (int start = 0; start < wineId.Length; start++)
                {
                    if (start == 0)
                    {
                        var_sql += "(" + WineId + "," + wineId[start] + ")";
                    }
                    else
                    {
                        var_sql += ",(" + WineId + "," + wineId[start] + ")";
                    }
                }

                cmd = new SqlCommand(var_sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteSelectedLocations(int WineId, string LocationIds)
        {
            string var_sql = "delete from LocationWines where MasterWineId=" + WineId + " and MasterLocationId in (" + LocationIds + ")";
            SqlConnection con = new SqlConnection(Configurations.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(var_sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
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
        #endregion
    }

    public class LocationWines
    {
        public int MasterLocationId { get; set; }
    }
}
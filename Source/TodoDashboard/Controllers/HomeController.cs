using DataTables.Mvc;
using System;
using System.Collections.Generic;
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
    public class HomeController : BaseController
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
        public HomeController(AbstractMasterLocationsService abstractMasterLocationsService, AbstractMasterWinesService abstractMasterWinesService,
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

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            ViewBag.States = BindDropDowns("states");
            ViewBag.ServiceTypes = BindDropDowns("servicetypes");
            ViewBag.BarTypes = BindDropDowns("bartypes");
            ViewBag.WineVaritals = BindDropDowns("winevaritals");
            ViewBag.Distributors = BindDropDowns("distributors");
            ViewBag.Tiers = BindDropDowns("tiers");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult BindLocationData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,string LocationId = "",string Location = "",int StateId = 0, int ServiceTypeId = 0,int BarTypeId = 0)
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
                abstractMasterLocations.LocationId = LocationId;
                abstractMasterLocations.LocationName = Location;
                abstractMasterLocations.StateId = StateId;
                abstractMasterLocations.ServiceTypeId = ServiceTypeId;
                abstractMasterLocations.BarTypeId = BarTypeId;

                var model = abstractMasterLocationsService.MasterLocations_All(pageParam, search, abstractMasterLocations);
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
        [ValidateAntiForgeryToken]
        public JsonResult BindWineData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string WineName = "", int VarietalId = 0, string Calories="", int DistributorId = 0, int TierId = 0)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                AbstractMasterWines abstractMasterWines = new MasterWines();
                abstractMasterWines.WineName = WineName;
                abstractMasterWines.MasterVarietalId = VarietalId;
                abstractMasterWines.Calories = Calories;
                abstractMasterWines.MasterDistributorId = DistributorId;
                abstractMasterWines.TierId = TierId;

                var model = abstractMasterWinesService.MasterWines_All(pageParam, search, abstractMasterWines);
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

        public JsonResult Delete(string ids, string action)
        {
            ids = ids.Substring(0, ids.Length - 1);
            string var_sql = "";
            if (action == "locations")
            {
                var_sql = "delete from MasterLocations where Id in (" + ids + ")";
            }
            else if (action == "wines")
            {
                var_sql = "delete from MasterWines where Id in (" + ids + ")";
            }
            

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
                else if(action == "states")
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


        public ActionResult AddDrink()
        {
            return View();
        }

        public ActionResult EditDrink()
        {
            return View();
        }

        public ActionResult ViewDrink()
        {
            return View();
        }
        #endregion
    }
}
using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TodoDashboard.Common.Paging;
using TodoDashboard.Infrastructure;
using TodoDashboard.Pages;
using TodoDashboard.Entities.Contract;
using TodoDashboard.Entities.V1;
using TodoDashboard.Services.Contract;
using TodoDashboard.Common;
using System.Data.SqlClient;

namespace TodoDashboard.Controllers
{
    public class MasterController : BaseController
    {
        #region Fields
        private readonly AbstractMasterWineVaritalsService abstractMasterWineVaritalsService;
        private readonly AbstractMasterBarTypesService abstractMasterBarTypesService;
        private readonly AbstractMasterServicesTypesService abstractMasterServicesTypesService;
        private readonly AbstractMasterTiersService abstractMasterTiersService;
        private readonly AbstractMasterDistributorsService abstractMasterDistributorsService;
        #endregion

        #region Ctor
        public MasterController(AbstractMasterWineVaritalsService abstractMasterWineVaritalsService, AbstractMasterBarTypesService abstractMasterBarTypesService
            , AbstractMasterServicesTypesService abstractMasterServicesTypesService, AbstractMasterTiersService abstractMasterTiersService,
            AbstractMasterDistributorsService abstractMasterDistributorsService)
        {
            this.abstractMasterWineVaritalsService = abstractMasterWineVaritalsService;
            this.abstractMasterBarTypesService = abstractMasterBarTypesService;
            this.abstractMasterServicesTypesService = abstractMasterServicesTypesService;
            this.abstractMasterTiersService = abstractMasterTiersService;
            this.abstractMasterDistributorsService = abstractMasterDistributorsService;
        }
        #endregion

        #region Methods


        #region Wine Varitals
        [ActionName(Actions.WineVaritals)]
        public ActionResult WineVaritals()
        {
            return View();
        }
        #endregion

        #region Bar Types
        [ActionName(Actions.BarTypes)]
        public ActionResult BarTypes()
        {
            return View();
        }

        #endregion

        #region Service Types
        [ActionName(Actions.ServiceTypes)]
        public ActionResult ServiceTypes()
        {
            return View();
        }
        #endregion

        #region Tiers
        [ActionName(Actions.Tiers)]
        public ActionResult Tiers()
        {
            return View();
        }
        #endregion

        #region Distributors
        [ActionName(Actions.Distributors)]
        public ActionResult Distributors()
        {
            return View();
        }
        #endregion

        #region General
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult BindData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string action = "")
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string search = Convert.ToString(requestModel.Search.Value);

                if (action == "winevaritals")
                {
                    var model = abstractMasterWineVaritalsService.MasterWineVaritals_All(pageParam, search);
                    totalRecord = (int)model.TotalRecords;
                    filteredRecord = (int)model.TotalRecords;
                    return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
                }
                else if (action == "bartypes")
                {
                    var model = abstractMasterBarTypesService.MasterBarTypes_All(pageParam, search);                    
                    totalRecord = (int)model.TotalRecords;
                    filteredRecord = (int)model.TotalRecords;
                    return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
                }
                else if (action == "servicetypes")
                {
                    var model = abstractMasterServicesTypesService.MasterServicesTypes_All(pageParam, search);
                    totalRecord = (int)model.TotalRecords;
                    filteredRecord = (int)model.TotalRecords;
                    return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
                }
                else if (action == "tiers")
                {
                    var model = abstractMasterTiersService.MasterTiers_All(pageParam, search);
                    totalRecord = (int)model.TotalRecords;
                    filteredRecord = (int)model.TotalRecords;
                    return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
                }
                else if (action == "distributors")
                {
                    var model = abstractMasterDistributorsService.MasterDistributors_All(pageParam, search);
                    totalRecord = (int)model.TotalRecords;
                    filteredRecord = (int)model.TotalRecords;
                    return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
                }

                return Json(new DataTablesResponse(requestModel.Draw, null, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogHelper.Log(ex);
                return Json(new object[] { null }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Upsert(int Id,string name, string action)
        {
            if (action == "winevaritals")
            {
                AbstractMasterWineVaritals abstractMasterWineVaritals = new MasterWineVaritals();
                abstractMasterWineVaritals.Id = Id;
                abstractMasterWineVaritals.Name = name;
                SuccessResult<AbstractMasterWineVaritals> successResult =  abstractMasterWineVaritalsService.MasterWineVaritals_Upsert(abstractMasterWineVaritals);
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            else if (action == "bartypes")
            {
                AbstractMasterBarTypes abstractMasterBarTypes = new MasterBarTypes();
                abstractMasterBarTypes.Id = Id;
                abstractMasterBarTypes.Name = name;
                SuccessResult<AbstractMasterBarTypes> successResult = abstractMasterBarTypesService.MasterBarTypes_Upsert(abstractMasterBarTypes);
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            else if (action == "servicetypes")
            {
                AbstractMasterServicesTypes abstractMasterServicesTypes = new MasterServicesTypes();
                abstractMasterServicesTypes.Id = Id;
                abstractMasterServicesTypes.Name = name;
                SuccessResult<AbstractMasterServicesTypes> successResult = abstractMasterServicesTypesService.MasterServicesTypes_Upsert(abstractMasterServicesTypes);
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            else if (action == "tiers")
            {
                AbstractMasterTiers abstractMasterTiers = new MasterTiers();
                abstractMasterTiers.Id = Id;
                abstractMasterTiers.Name = name;
                SuccessResult<AbstractMasterTiers> successResult = abstractMasterTiersService.MasterTiers_Upsert(abstractMasterTiers);
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            else if (action == "distributors")
            {
                AbstractMasterDistributors abstractMasterDistributors = new MasterDistributors();
                abstractMasterDistributors.Id = Id;
                abstractMasterDistributors.Name = name;
                SuccessResult<AbstractMasterDistributors> successResult = abstractMasterDistributorsService.MasterDistributors_Upsert(abstractMasterDistributors);
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            return Json("400", JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string ids,string action)
        {
            ids = ids.Substring(0, ids.Length - 1);
            string var_sql = "";
            if (action == "winevaritals")
            {
                var_sql = "delete from MasterWineVaritals where Id in (" + ids + ")";
            }
            else if (action == "bartypes")
            {
                var_sql = "delete from MasterBarTypes where Id in (" + ids + ")";
            }
            else if (action == "servicetypes")
            {
                var_sql = "delete from MasterServicesTypes where Id in (" + ids + ")";
            }
            else if (action == "tiers")
            {
                var_sql = "delete from MasterTiers where Id in (" + ids + ")";
            }
            else if (action == "distributors")
            {
                var_sql = "delete from MasterDistributors where Id in (" + ids + ")";
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
            catch(Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetById(int Id, string action)
        {
            if (action == "winevaritals")
            {
                SuccessResult<AbstractMasterWineVaritals> successResult = abstractMasterWineVaritalsService.MasterWineVaritals_Id(Id);
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            else if (action == "bartypes")
            {
                SuccessResult<AbstractMasterBarTypes> successResult = abstractMasterBarTypesService.MasterBarTypes_Id(Id);
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            else if (action == "servicetypes")
            {
                SuccessResult<AbstractMasterServicesTypes> successResult = abstractMasterServicesTypesService.MasterServicesTypes_Id(Id);
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            else if (action == "tiers")
            {
                SuccessResult<AbstractMasterTiers> successResult = abstractMasterTiersService.MasterTiers_Id(Id);
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            else if (action == "distributors")
            {
                SuccessResult<AbstractMasterDistributors> successResult = abstractMasterDistributorsService.MasterDistributors_Id(Id);
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            return Json("200", JsonRequestBehavior.AllowGet);
        }
        #endregion



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult BindData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        //{
        //    try
        //    {
        //        int totalRecord = 0;
        //        int filteredRecord = 0;

        //        PageParam pageParam = new PageParam();
        //        pageParam.Offset = requestModel.Start;
        //        pageParam.Limit = requestModel.Length;

        //        List<Drinks> drinks = new List<Drinks>();

        //        Drinks Drinks = new Drinks();
        //        Drinks.Name = "Bacardi Mojito";
        //        Drinks.Spirit = "Rum";
        //        Drinks.Brand = "Bacardi Superior";
        //        Drinks.Ingredients = "Lime Wedges 2 each (in drinks as garnish)"+"<br/>"+"Mini Leaves 4 each";
        //        Drinks.Garnish = "Lime Wheel, Mint Spring";
        //        Drinks.Glassware = "Collins";
        //        Drinks.Price = "13";
        //        Drinks.Location = "Akershus"+"<br/>"+"Ale & Compass"+ "<br/>" + "Boma";
        //        Drinks.LoungeLevel = "Signature";
        //        Drinks.Seasonal = "Domestic"+ "<br/>" + "Resort"+ "<br/>" + "Moderate";
        //        Drinks.Photo = "../assets/images/xs/wine.png";

        //        drinks.Add(Drinks);


        //        Drinks = new Drinks();
        //        Drinks.Name = "Banana Spiced Rum";
        //        Drinks.Spirit = "Rum";
        //        Drinks.Brand = "Captain" + "<br/>" + "Morgon" + "<br/>" + "Original" + "<br/>" + "Spiced";
        //        Drinks.Ingredients = "RumChata 1 oz" + "<br/>" + "Captain Morgon Original"+"<br/>"+"Spiced Rum 1 oz"+"<br/>"+"BOLS Creme de B anana 1 oz";
        //        Drinks.Garnish = "None";
        //        Drinks.Glassware = "Martini";
        //        Drinks.Price = "13";
        //        Drinks.Location = "Hollywood & Vine" + "<br/>" + "Marana Melrose's" + "<br/>" + "Olieia's Cafe";
        //        Drinks.LoungeLevel = "Moderate";
        //        Drinks.Seasonal = "Domestic" + "<br/>" + "Resort" + "<br/>" + "Luxury";
        //        Drinks.Photo = "../assets/images/xs/wine.png";

        //        drinks.Add(Drinks);


        //        Drinks = new Drinks();
        //        Drinks.Name = "Bacardi Mojito";
        //        Drinks.Spirit = "Rum";
        //        Drinks.Brand = "Bacardi Superior";
        //        Drinks.Ingredients = "Lime Wedges 2 each (in drinks as garnish)" + "<br/>" + "Mini Leaves 4 each";
        //        Drinks.Garnish = "Lime Wheel, Mint Spring";
        //        Drinks.Glassware = "Collins";
        //        Drinks.Price = "13";
        //        Drinks.Location = "Akershus" + "<br/>" + "Ale & Compass" + "<br/>" + "Boma";
        //        Drinks.LoungeLevel = "Signature";
        //        Drinks.Seasonal = "Domestic" + "<br/>" + "Resort" + "<br/>" + "Moderate";
        //        Drinks.Photo = "../assets/images/xs/wine.png";

        //        drinks.Add(Drinks);

        //        string search = requestModel.Search.Value;
        //        //var model = null;
        //        totalRecord = (int)3;
        //        filteredRecord = (int)3;

        //        return Json(new DataTablesResponse(requestModel.Draw, drinks, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        //ErrorLogHelper.Log(ex);
        //        return Json(new object[] { null }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //public ActionResult AddDrink()
        //{
        //    return View();
        //}

        //public ActionResult EditDrink()
        //{
        //    return View();
        //}

        //public ActionResult ViewDrink()
        //{
        //    return View();
        //}
        #endregion
    }

    public class MasterControllerDrinks
    {
        public int Id;
        public string Name;
        public string Spirit;
        public string Brand;
        public string Ingredients;
        public string Garnish;
        public string Glassware;
        public string Price;
        public string Location;
        public string LoungeLevel;
        public string Seasonal;
        public string Photo;
    }
}
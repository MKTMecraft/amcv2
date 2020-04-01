using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TodoDashboard.Common.Paging;
using TodoDashboard.Infrastructure;
using TodoDashboard.Pages;

namespace TodoDashboard.Controllers
{
    public class HomeController : BaseController
    {
        #region Fields
        #endregion

        #region Ctor
        #endregion

        #region Methods

        [ActionName(Actions.Index)]
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

                List<Drinks> drinks = new List<Drinks>();

                Drinks Drinks = new Drinks();
                Drinks.Name = "Bacardi Mojito";
                Drinks.Spirit = "Rum";
                Drinks.Brand = "Bacardi Superior";
                Drinks.Ingredients = "Lime Wedges 2 each (in drinks as garnish)"+"<br/>"+"Mini Leaves 4 each";
                Drinks.Garnish = "Lime Wheel, Mint Spring";
                Drinks.Glassware = "Collins";
                Drinks.Price = "13";
                Drinks.Location = "Akershus"+"<br/>"+"Ale & Compass"+ "<br/>" + "Boma";
                Drinks.LoungeLevel = "Signature";
                Drinks.Seasonal = "Domestic"+ "<br/>" + "Resort"+ "<br/>" + "Moderate";
                Drinks.Photo = "../assets/images/xs/wine.png";

                drinks.Add(Drinks);


                Drinks = new Drinks();
                Drinks.Name = "Banana Spiced Rum";
                Drinks.Spirit = "Rum";
                Drinks.Brand = "Captain" + "<br/>" + "Morgon" + "<br/>" + "Original" + "<br/>" + "Spiced";
                Drinks.Ingredients = "RumChata 1 oz" + "<br/>" + "Captain Morgon Original"+"<br/>"+"Spiced Rum 1 oz"+"<br/>"+"BOLS Creme de B anana 1 oz";
                Drinks.Garnish = "None";
                Drinks.Glassware = "Martini";
                Drinks.Price = "13";
                Drinks.Location = "Hollywood & Vine" + "<br/>" + "Marana Melrose's" + "<br/>" + "Olieia's Cafe";
                Drinks.LoungeLevel = "Moderate";
                Drinks.Seasonal = "Domestic" + "<br/>" + "Resort" + "<br/>" + "Luxury";
                Drinks.Photo = "../assets/images/xs/wine.png";

                drinks.Add(Drinks);


                Drinks = new Drinks();
                Drinks.Name = "Bacardi Mojito";
                Drinks.Spirit = "Rum";
                Drinks.Brand = "Bacardi Superior";
                Drinks.Ingredients = "Lime Wedges 2 each (in drinks as garnish)" + "<br/>" + "Mini Leaves 4 each";
                Drinks.Garnish = "Lime Wheel, Mint Spring";
                Drinks.Glassware = "Collins";
                Drinks.Price = "13";
                Drinks.Location = "Akershus" + "<br/>" + "Ale & Compass" + "<br/>" + "Boma";
                Drinks.LoungeLevel = "Signature";
                Drinks.Seasonal = "Domestic" + "<br/>" + "Resort" + "<br/>" + "Moderate";
                Drinks.Photo = "../assets/images/xs/wine.png";

                drinks.Add(Drinks);

                string search = requestModel.Search.Value;
                //var model = null;
                totalRecord = (int)3;
                filteredRecord = (int)3;

                return Json(new DataTablesResponse(requestModel.Draw, drinks, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogHelper.Log(ex);
                return Json(new object[] { null }, JsonRequestBehavior.AllowGet);
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

    public class Drinks
    {
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
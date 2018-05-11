using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantBusiness;

namespace RestaurantPL.Controllers
{
    public class HomeController : Controller
    {
        RestaurantUtility rutility = new RestaurantUtility();

        //public ActionResult Index()
        //{
        //    //return View(rutility.DisplayTop3());
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
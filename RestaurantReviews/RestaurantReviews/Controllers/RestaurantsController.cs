using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantBL;
using RestaurantDL;

namespace RestaurantReviews.Controllers
{
    public class RestaurantsController : Controller
    {
        RestaurantUtility restaurant = new RestaurantUtility();
        DButilities dbutilities = new DButilities();

        // GET: Restaurants
        public ActionResult Index()
        {
            ViewBag.restaurants = dbutilities.GetRestaurants();
            return View();
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurants/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

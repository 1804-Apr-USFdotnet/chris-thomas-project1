using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantBusiness;
using RestaurantDL;
using NLog;

namespace RestaurantPL.Controllers
{
    public class ReviewsController : Controller
    {
        RestaurantUtility revutility = new RestaurantUtility();
        DButilities dbutilities = new DButilities();

        // GET: Reviews
        public ActionResult Index()
        {
            int id = 1;
            ViewBag.reviews = dbutilities.GetAllReviews(id);
            return View();
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            return View(dbutilities.GetAllReviews(id));
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
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

        public ActionResult Edit(int id)
        {
            return View(dbutilities.GetAllReviews(id));
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestaurantBusiness.Review rest)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //business logic
                    revutility.EditReview(rest, id);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(revutility);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reviews/Delete/5
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

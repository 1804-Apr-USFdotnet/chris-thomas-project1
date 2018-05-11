using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantBusiness;
using NLog;

namespace RestaurantPL.Controllers
{
    public class ReviewsController : Controller
    {
        RestaurantUtility revutility = new RestaurantUtility();
        List<Review> r = new List<Review>();
        private Logger log;

        // GET: Reviews
        public ActionResult Index()
        {
            ViewBag.reviews = revutility.GetAllReviews();
            return View();
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            //var bl = new RestaurantBusiness.RestaurantUtility();
            //var x = bl.DisplayReview(id);
            //return View(x);
            return RedirectToAction("Details", "Restaurants", new { id = id });
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            //ViewBag.reviews = id;
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantBusiness.Review rev)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //business logic
                    revutility.AddReview(rev);
                    return RedirectToAction("Index");
                }
                else
                {
                    log = LogManager.GetLogger("errors");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(revutility.GetAllReviews(id));
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestaurantBusiness.Review rev)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //business logic
                    revutility.EditReview(rev, id);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(revutility);
                }
            }
            catch (Exception)
            {
                log = LogManager.GetLogger("errors");
                return View();
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View(revutility.GetAllReviews(id));
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RestaurantBusiness.Review rev)
        {
            try
            {
                // TODO: Add delete logic here
                RestaurantDL.Review reviewToDelete = new RestaurantDL.Review();
                reviewToDelete = revutility.DisplayReview(id);
                revutility.DeleteReview(id);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                log = LogManager.GetLogger("errors");
                log.Error($"[Restaurants Controller] [Details] Exception thrown: {e.Message}");
                return View();
            }
        }
    }
}
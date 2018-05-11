//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using RestaurantBusiness;
//using NLog;

//namespace RestaurantPL.Controllers
//{
//    public class ReviewsController : Controller
//    {
//        RestaurantUtility revutility = new RestaurantUtility();

//        // GET: Reviews
//        public ActionResult Index()
//        {
//            int id = 1;
//            ViewBag.reviews = dbutilities.GetAllReviews(id);
//            return View();
//        }

//        // GET: Reviews/Details/5
//        public ActionResult Details(int id)
//        {
//            return View(dbutilities.GetAllReviews(id));
//        }

//        // GET: Reviews/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Reviews/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(RestaurantBusiness.Review rev)
//        {
//            try
//            {
//                // TODO: Add insert logic here
//                if (ModelState.IsValid)
//                {
//                    //business logic
//                    revutility.AddReview(rev);
//                    return RedirectToAction("Index");
//                }
//                else
//                {
//                    return View(revutility);
//                }
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        public ActionResult Edit(int id)
//        {
//            return View(dbutilities.GetAllReviews(id));
//        }

//        // POST: Restaurants/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, RestaurantBusiness.Review rev)
//        {
//            try
//            {
//                // TODO: Add update logic here
//                if (ModelState.IsValid)
//                {
//                    //business logic
//                    revutility.EditReview(rev, id);
//                    return RedirectToAction("Index");
//                }
//                else
//                {
//                    return View(revutility);
//                }
//            }
//            catch (Exception)
//            {
//                return View();
//            }
//        }

//        // GET: Reviews/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View(dbutilities.GetAllReviews(id));
//        }

//        // POST: Reviews/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, RestaurantBusiness.Review rev)
//        {
//            try
//            {
//                // TODO: Add delete logic here
//                revutility.DeleteReview(id);
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
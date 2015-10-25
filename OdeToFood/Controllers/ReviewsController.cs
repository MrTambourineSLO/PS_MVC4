using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        //Data source 
        OdeToFoodDb _db = new OdeToFoodDb();

        //This id parameter is not review id but
        //restaurant id
        //We use Bind attribute to let model binder know that
        //"restaurantId" is a n alias for id
        public ActionResult Index([Bind(Prefix = "id")]int restaurantId)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Review.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new {id = review.RestaurantId});
            }
            /*If something went wrong return back to form*/
            return View(review);
        }
        //We have to implement Dispose method
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }

}

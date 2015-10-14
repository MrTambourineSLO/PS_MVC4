using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        //1st we INSTANTIATE OdeToFoodDb
        OdeToFoodDb _db = new OdeToFoodDb();
        //We add search term to controller
        public ActionResult Index(string searchTerm = null)
        {
       
            var model = _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Select(r => new RestaurantListViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()

                }
                );


            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Saso";
            model.Location = "Idrija, Slovenia";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Since this is a disposable resource we should override 
        //DISPOSE - Dispose API in .NET is just a way to clean
        //up resources that may be open
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
                
            }
            base.Dispose(disposing);
        }
    }
}

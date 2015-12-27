using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;
using PagedList;

namespace OdeToFood.Controllers
{
   
    public class HomeController : Controller
    {

        //1st we INSTANTIATE OdeToFoodDb
        OdeToFoodDb _db = new OdeToFoodDb();
        //We add search term to controller
        /*
         JQ documentation on Autocomplete tells us that when the user
         * is typing it will send a request to the server and include
         * the parameter in the request called "term"
         */
        public ActionResult Autocomplete(string term)
        {
            /*I take term sent from JQ and query DB w/ it*/
            var model =
                //Give us restaurants
                _db.Restaurants
                //where the name of restaurants starts with term
                    .Where(r => r.Name.StartsWith(term))
                    //Limit result set to first 10
                    .Take(10)
                    //We do projection w/ select ie
                    //return every restaurant into an object
                    .Select(r => new
                    {
                        //that has a label property and that label prop
                        //will turn into restaurant's name (label, value etc are
                        //required by JQ
                        label = r.Name
                    });
            //We put that into JSON format
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Index(string searchTerm = null, int page = 1)
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
                ).ToPagedList(page, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }


            return View(model);
        }
        /*Authorize attribute w/o parameters says:
         * "Only authenticated users are authorized to
         * invoke this controller action
         */
        
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

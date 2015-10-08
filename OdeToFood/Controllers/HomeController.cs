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
        public ActionResult Index()
        {
            //We retrieve all restaurants from Restaurants
            var model = _db.Restaurants.ToList();
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

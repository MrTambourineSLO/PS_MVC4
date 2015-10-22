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
        

        public ActionResult Index()
        {
            var model = from r in _reviews
                orderby r.Country
                select r;


            return View(model);
        }
    }

}

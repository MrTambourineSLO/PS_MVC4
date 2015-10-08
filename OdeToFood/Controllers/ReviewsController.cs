//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using OdeToFood.Models;

//namespace OdeToFood.Controllers
//{
//    public class ReviewsController : Controller
//    {
//        [ChildActionOnly]
//        public ActionResult BestReview()
//        {
//            var bestReview = from r in _reviews
//                orderby r.Rating descending
//                select r;

//            return PartialView("_Review",bestReview.First());
//        }        
//        // GET: /Reviews/

//        public ActionResult Index()
//        {
//            var model = from r in _reviews
//                orderby r.Country
//                select r;


//            return View(model);
//        }
//        static List<RestaurantReview> _reviews = new List<RestaurantReview>
//        {
//            new RestaurantReview
//            {
//                Id = 1,
//                Name = "Cinnamon Club",
//                City = "London",
//                Country = "UK",
//                Rating = 10
//            },
//            new RestaurantReview
//            {
//                Id = 2,
//                Name = "Marakesh",
//                City = "D.C.",
//                Country = "USA",
//                Rating = 10
//            },
//            new RestaurantReview
//            {
//                Id = 3,
//                Name = "The House of Elliot",
//                City = "Ghet",
//                Country = "Belgium",
//                Rating = 10

                
//            }

//        }; 

//    }

//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        //If we provice an argument to the AR in controller
        //ASP will try it's best to find the relevant data
        //in routing data, query string and posted form values

        //Here it will see that /cuisine/name is the value we want
        //Action Verb: HttpPost
        [HttpPost]
        public ActionResult Search(string name ="Slovenian")
        {
            var message = Server.HtmlEncode(name);
            return Content(message);
        }
        //Action Verb: HttpGet
        [HttpGet]
        public ActionResult Search()
        {
            return Content("Search!");
        }

    }
}

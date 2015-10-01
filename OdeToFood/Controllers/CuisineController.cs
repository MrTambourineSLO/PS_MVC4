using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Search(string name)
        {
            var message = Server.HtmlEncode(name);
            //return Content(name);
            //Permanent redirect
            //return RedirectPermanent("http://microsoft.com");
            
            //Temporary redirect - it works w/ Routing Engine
            return RedirectToAction("Index", "Home",new{name=name});
        }

    }
}

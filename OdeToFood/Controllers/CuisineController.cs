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
            
            //-- w/ RedirectToRoute we don't pass controller and action name as parameters,
            //rather we pass them as anonymously typed object.
            return RedirectToRoute("Default", new {controller = "Home", action = "About"});
        }

    }
}

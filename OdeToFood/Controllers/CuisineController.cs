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

        //Eg: User has to be admin
        //[Authorize(Roles = "Admin")]
        //User has to be logged in:
        

        public ActionResult Search(string name ="Slovenian")
        {
            throw new Exception("Something terrible has happened.");
            var message = Server.HtmlEncode(name);
            return Content(message);
        }
        //Action Verb: HttpGet
        

    }
}

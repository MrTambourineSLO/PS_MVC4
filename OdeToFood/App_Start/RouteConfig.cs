using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeToFood
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /************************************************
             *WARNING: Order of routes is important!!!
             *Our default route will match almost any case
             *so it is wise to use it as the last on the list
             *of routes. First routes should be more SPECIFIC
             *and not "ALL ENCOMPASING" (ie the ones that provide
             *default values for all parameters!!!)
             *************************************************/
            
            //Cousine/french/ - here second part of path isn't really an ACTION
            //but rather a parameter
            routes.MapRoute(
                name: "Cuisine",
                url: "cuisine/{name}",
                //NOTE: Route has to know controller and action names!
                defaults: new {controller ="Cuisine", action="Search", name=UrlParameter.Optional}
            
                );
            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
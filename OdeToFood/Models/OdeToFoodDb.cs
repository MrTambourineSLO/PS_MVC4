using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    //This class needs to derive from EF class
    //DbContext
    public class OdeToFoodDb : DbContext
    {
        /*We have properties of type DbSet that represent
         * the entities we want to query and PERSIST*/
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Review { get; set; }
    }
}
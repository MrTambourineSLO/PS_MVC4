using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace OdeToFood.Models
{
    //This class needs to derive from EF class
    //DbContext
    public class OdeToFoodDb : DbContext
    {
        public OdeToFoodDb() : base("name=DefaultConnection")
        {
            
        }
        /*We have properties of type DbSet that represent
         * the entities we want to query and PERSIST*/
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Review { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}
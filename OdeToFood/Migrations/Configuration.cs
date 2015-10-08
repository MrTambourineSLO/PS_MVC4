using System.Collections.Generic;
using OdeToFood.Models;

namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            //Let's put some code that will populate restaurants for us:
            context.Restaurants.AddOrUpdate(r=> r.Name,
                new Restaurant {Name = "Sabatino's", City = "Baltimore", Country = "USA"},
                new Restaurant{Name = "Great Lake", City = "Chicago", Country = "USA"},
                new Restaurant
                {
                    Name = "Smaka", City = "Gotenburg", Country = "Sweden",
                    Reviews = new List<RestaurantReview>
                    {
                        new RestaurantReview{Rating = 9, Body = "Great Food!"}
                    }
                });
        }
    }
}

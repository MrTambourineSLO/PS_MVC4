using System.Collections.Generic;
using System.Web.Security;
using OdeToFood.Models;
using WebMatrix.WebData;

namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

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
                        new RestaurantReview{Rating = 9, Body = "Great Food!",Reviewer = "Scott"}
                    }
                });
            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r=>r.Name,
                    new Restaurant
                    {
                        Name = i.ToString(),
                        City = "Nowhere",
                        Country = "USA"
                    });
            }
            SeedMembership();
        }

        private void SeedMembership()
        {
            //We init db connection to make sure everything is setup and schema is in place for the 
            //SimpleMembershipProvider
            
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile","UserId",
                "UserName", autoCreateTables:true);
            
            //Get access for the current role provider and current membership provider
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            //We check if role exists, if not we create it 
            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            //Does user s allen exists ? 
            if (membership.GetUser("sallen", false) == null)
            {
                //If not, create that user w/ that password
                membership.CreateUserAndAccount("sallen","iamalittleteapot");
            }
            //IF s allen isn't in admin role, add it to admin role
            //We ALLWAYS check first if role/user exists before adding them, because each time
            //we execute DB update in PM console seed method will run!!!
            if (!roles.GetRolesForUser("sallen").Contains("Admin"))
            {
                roles.AddUsersToRoles(new []{"sallen"},new []{"admin"});
            }
        }
    }
}

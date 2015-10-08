using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        //For storing text
        public string Body { get; set; }
        public string Reviewer { get; set; }
        public int RestaurantId { get; set; }
    }
}
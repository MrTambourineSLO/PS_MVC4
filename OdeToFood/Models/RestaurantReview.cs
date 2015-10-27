using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        /*Data annotation for range*/
        [Range(1,10)]
        /*Required is redundant, value types cannot
         be left null!*/
        [Required]
        public int Rating { get; set; }
        //For storing text
        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
        
        public string Reviewer { get; set; }
        public int RestaurantId { get; set; }
    }
}
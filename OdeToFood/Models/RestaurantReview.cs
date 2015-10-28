using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
   
    public class RestaurantReview : IValidatableObject
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
        [StringLength(1024,ErrorMessage = "Predolgo")]
        public string Body { get; set; }
        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "Anonymous")]
        public string Reviewer { get; set; }
        public int RestaurantId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && Reviewer.ToLower().StartsWith("saso"))
            {
                /*Otherwise it will produce empty IEnumerable*/
                yield return new ValidationResult("Sorry Saso, you can't do this");
            }
        }
    }
}
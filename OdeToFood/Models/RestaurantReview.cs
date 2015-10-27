using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    /*1st we derive from base class ValidationAttribute*/
    public class MaxWordsAttribute : ValidationAttribute
    {
        public MaxWordsAttribute(int maxWords) :
            base ("{0} has too many words")
        {
            _maxWords = maxWords;
        }
        /*We override method IsValid*/
        /*ModelBinder will pass in reviewer name eg as value*/
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                /*We're simply checking how many spaces are in there and 
                 putting it to array*/
                if (valueAsString.Split(' ').Length > _maxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }

        private readonly int _maxWords;
    }
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
        [StringLength(1024,ErrorMessage = "Predolgo")]
        public string Body { get; set; }
        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "Anonymous")]
        public string Reviewer { get; set; }
        public int RestaurantId { get; set; }
    }
}
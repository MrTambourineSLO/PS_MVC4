using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Models;

/*
 * A restaurant's overall rating can be calculated using various methods.
 * For this app we'll want to try different methods over time,
 * for starters we'll allow an admin to toggle between 2 different techniques
 * 
 * 1.   Simple mean of the "rating" value for the most recent n reviews
 *      (admin can configure the value n).
 *      
 * 2.   Weighted mean of the last n reviews. The most recent n/2 reviews will
 *      be weighted 2ce as much and the oldest n/2 reviews
 *      
 * Overall rating must be a whole number
 */
namespace OdeToFood.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //First we need a restaurant
            var data = new Restaurant();
            data.Reviews = new List<RestaurantReview>();
            data.Reviews.Add(new RestaurantReview(){Rating = 4});

            //Lets create some method to calculate our rating - "rater"

            var rater = new RestaurantRater(data);
            //ComputerRating accepts number of reviews to use
            var result = rater.ComputeRating(10);

            //Assert the result
            Assert.AreEqual(4,result.Rating);
        }
    }
}

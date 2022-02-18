using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_N01519708.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// Takes food item selection as input and returns total calories in the meal
        /// </summary>
        /// <param name="burger">number indicating choice of burger</param>
        /// <param name="drink">number indicating choice of drink</param>
        /// <param name="side">number indicating choice of side</param>
        /// <param name="dessert">number indicating choice of dessert</param>
        /// <returns>string indicating total calorie count of the meal</returns>
        /// Example:
        /// api/J1/Menu/4/4/4/4  ===> "Your total calorie count is 0"
        /// api/J1/Menu/1/2/3/4  ===> "Your total calorie count is 691"
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string Get(int burger, int drink, int side, int dessert)
        {
            int totalCalories = 0;
            int burgerCalories;
            int drinkCalories;
            int sidesCalories;
            int dessertCalories;
            Dictionary<int, int> burgersAndCalories = new Dictionary<int, int>()
            {
                {1, 461},
                {2, 431},
                {3, 420},
                {4, 0}
            };

            Dictionary<int, int> drinksAndCalories = new Dictionary<int, int>()
            {
                {1, 130},
                {2, 160},
                {3, 118},
                {4, 0}
            };

            Dictionary<int, int> sidesAndCalories = new Dictionary<int, int>()
            {
                {1, 100},
                {2, 57},
                {3, 70},
                {4, 0}
            };

            Dictionary<int, int> dessertAndCalories = new Dictionary<int, int>()
            {
                {1, 167},
                {2, 266},
                {3, 75},
                {4, 0}
            };

            if (burgersAndCalories.TryGetValue(burger, out burgerCalories))
            {
                totalCalories += burgerCalories;
            }

            if (drinksAndCalories.TryGetValue(drink, out drinkCalories))
            {
                totalCalories += drinkCalories;
            }

            if (sidesAndCalories.TryGetValue(side, out sidesCalories))
            {
                totalCalories += sidesCalories;
            }

            if (dessertAndCalories.TryGetValue(dessert, out dessertCalories))
            {
                totalCalories += dessertCalories;
            }

            string message = $"Your total calorie count is {totalCalories}";

            return message;
        }
    }
}

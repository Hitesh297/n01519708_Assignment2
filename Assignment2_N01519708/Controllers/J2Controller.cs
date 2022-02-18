using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_N01519708.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// Takes the number of sides for 2 dices and returns the number of ways in which 10 can be the outcome.
        /// </summary>
        /// <param name="m"> number of sides of dice 1</param>
        /// <param name="n"> number of sides of dice 2</param>
        /// <returns>string indicating number of ways, 10 can be the outcome</returns>
        /// Example:
        /// api/J2/DiceGame/6/8  ===> "There are 5 total ways to get the sum 10."
        /// api/J2/DiceGame/12/4  ===> "There are 4 total ways to get the sum 10."
        /// api/J2/DiceGame/5/5   ===> "There is 1 way to get the sum 10."
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string Get(int m, int n)
        {
            int outcomeAsTen = 0;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if(i+j == 10)
                    {
                        outcomeAsTen++;
                    }
                }
            }

            string message = $"There are {outcomeAsTen} total ways to get the sum 10.";

            if (outcomeAsTen == 1)
            {
                message = $"There is {outcomeAsTen} way to get the sum 10.";
            }

            return message;
        }
    }
}

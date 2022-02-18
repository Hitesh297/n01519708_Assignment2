using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

namespace Assignment2_N01519708.Controllers
{
    public class J3Controller : ApiController
    {
        // This J3 problem is available at :
        // https://cemc.math.uwaterloo.ca/contests/computing/2006/stage1/juniorEn.pdf

        /// <summary>
        /// Takes words seperated by comma(,) as input and return the time taken to type them on a cell phone keyboard
        /// </summary>
        /// <param name="inputWords">takes strings seperated by commas as paramter</param>
        /// <returns>Return time taken to type them on cell phone (in seconds)</returns>
        /// Example:
        /// GET api/J3/CellPhoneMessage/a,dada,bob,abba,cell,www
        /// Output:
        /// "a =====> 1",
        /// "dada =====> 4",
        /// "bob =====> 7",
        /// "abba =====> 12",
        /// "cell =====> 13",
        /// "www =====> 7"
        [Route("api/J3/CellPhoneMessage/{inputWords}")]
        public List<string> Get(string inputWords)
        {
            string[] words = inputWords.Split(',');
            int waitTime = 2;
            List<string> output = new List<string>();

            //below is an array of object that represents the button on cell phone, internal array consists of 3 parts
            //part 1 represents the character on the button
            //part 2 represents the number of clicks required to type that character
            //part 3 represents the button number the character is on
            object[][] keyboard = new object[][] { 
                new object[3] {'a',1, 2},
                new object[3] {'b',2, 2},
                new object[3] {'c',3, 2},

                new object[3] {'d',1, 3},
                new object[3] {'e',2, 3},
                new object[3] {'f',3, 3},

                new object[3] {'g',1, 4},
                new object[3] {'h',2, 4},
                new object[3] {'i',3, 4},

                new object[3] {'j',1, 5},
                new object[3] {'k',2, 5},
                new object[3] {'l',3, 5},

                new object[3] {'m',1, 6},
                new object[3] {'n',2, 6},
                new object[3] {'o',3, 6},

                new object[3] {'p',1, 7},
                new object[3] {'q',2, 7},
                new object[3] {'r',3, 7},
                new object[3] {'s',4, 7},

                new object[3] {'t',1, 8},
                new object[3] {'u',2, 8},
                new object[3] {'v',3, 8},

                new object[3] {'w',1, 9},
                new object[3] {'x',2, 9},
                new object[3] {'y',3, 9},
                new object[3] {'z',4, 9},
            };



            for (int i = 0; i < words.Count(); i++)
            {
                //we keep track of previous button click to add 2 sec wait if next character is on the same button
                int previousButton = -1;
                int totalTimeSpent = 0;
                foreach (var letter in words[i])
                {
                    foreach (var key in keyboard)
                    {
                        //we itterate through keypad to find key with the letter
                        if ((char)key[0] == letter)
                        {
                            //add wait time if next letter is on the same button
                            if ((int)key[2] == previousButton)
                            {
                                totalTimeSpent = totalTimeSpent + waitTime;
                            }

                            //add time taken to type a character
                            totalTimeSpent = totalTimeSpent + (int)key[1];
                            previousButton = (int)key[2];
                        }
                    }
                }
                output.Add($"{words[i]} =====> {totalTimeSpent}");
            }

            return output; 
        }
    }
}

//By Brandon Blanker Lim-it @flamendless
//For educational Purposes

using System;
using System.Collections.Generic;

namespace ITOlympics2019
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //NOTE:
            //The problems here are not exactly as they were given in the question.
            //I am just recollecting the details from memory.
            //The solutions may not be the best and most optimized. Pull Requests are welcome.

            int current_question = 1; //change this accordingly for individual testing
            bool do_all = true; //mark this to true to test all

            if (!do_all)
            {
                switch (current_question)
                {
                    case 1: Easy1.Do(); break;
                    case 2: Easy2.Do(); break;
                    case 3: Average1.Do(); break;
                    case 4: Average2.Do(); break;
                    case 5: Difficult1.Do(); break;
                    case 6: Difficult2.Do(); break;
                }
            }
            else
            {
                Easy1.Do();
                Easy2.Do();
                Average1.Do();
                Average2.Do();
                Difficult1.Do();
                Difficult2.Do();
            }
        }
    }
}

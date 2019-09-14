using System;

namespace ITOlympics2019
{
    public static class Difficult1
    {
        public static void Do()
        {
            string problem = @"Difficult Problem #1:
            Show the product of two numbers.

            Constraints:
                long and ulong are not accepted.
                0 < a;
                1000000 > a < 100000000000000000";
            Console.WriteLine(problem);

            //This is to make sure that the first input is valid before proceeding to the second input
            bool success_a = false;

            double a;
            double b;
            double prod;

            double min_value = 1000000;
            double max_value = 100000000000000000;

            Console.WriteLine("Enter first number:");
            //Try to parse the input if it is a number or not.
            //If it is valid, store that as a double in variable a
            if (double.TryParse(Console.ReadLine(), out a))
            {
                //Check for constraints
                if (a < min_value || a > max_value || a < 0)
                    Console.WriteLine("Input must be positive and withing the [{0}, {1}] range", min_value, max_value);
                else
                    success_a = true;
            }
            else
                Console.WriteLine("Input must be a number");

            //Make sure first input is valid
            if (success_a)
            {
                //Try to parse the input if it is a number or not.
                //If it is valid, store that as a double in variable b
                Console.WriteLine("Enter second number:");
                if (double.TryParse(Console.ReadLine(), out b))
                {
                    //Check for constraints
                    if (b < min_value || b > max_value || b < 0)
                        Console.WriteLine("Input must be positive and withing the [{0}, {1}] range", min_value, max_value);
                    else
                    {
                        //Everything is successful, so we proceed to displaying the product
                        prod = a * b;

                        //We have to specify a format specifier for the Console.WriteLine.
                        //Doing just Console.WriteLine(prod.ToString()); will not display the exact number
                        Console.WriteLine("{0}", prod.ToString());
                    }
                }
            }
            else
                Console.WriteLine("Input must be a number");
        }
    }
}

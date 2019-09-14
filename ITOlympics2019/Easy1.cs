using System;
using System.Collections.Generic;

namespace ITOlympics2019
{
    public static class Easy1
    {
        public static void Do()
        {
            string problem = @"Easy Problem #1:
            Create an ordered list with values of 1 to n.
            First, remove the first element from the left to the right alternatingly.
            Second, remove the first element from the right to the left alternatingly.
            Repeat this process alternatingly until only one element is left.

            Constraints:
                1 < n
            ";

            Console.WriteLine(problem);
            Console.WriteLine("Enter n:");

            //Try to parse the input to make sure the input is integer.
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                //Since we have a constraint, we should not accept negative input
                if (n < 0)
                    Console.WriteLine("Input must be positive");
                else
                {
                    //Create a list
                    List<int> list = new List<int>(n);
                    //Fill the list with elements 1 to n
                    for (int i = 0; i < n; i++) list.Add(i + 1);

                    //Repeat the process until there is only one element left in the list
                    while (list.Count > 1)
                    {
                        //NOTE: we should not remove any element in the list WHILE
                        //we are iterating in it because that will lead to shifting of elements
                        //and thus will lead to undesired behaviours. We will set the value to 0
                        //first and then remove elements with value of 0 at the end for safety

                        //left to right
                        for (int i = 0; i < list.Count; i += 2)
                            list[i] = 0;

                        //Do the removing here if the element value is 0
                        list.RemoveAll((obj) => obj == 0);

                        //Check if there is only one element left, if so, break out of the while-loop
                        if (list.Count == 1) break;

                        //right to left
                        for (int i = list.Count - 1; i > 0; i -= 2)
                            list[i] = 0;

                        //Do the removing here if the element value is 0
                        list.RemoveAll((obj) => obj == 0);
                    }

                    //This is certain to print only the remaining value
                    foreach (int num in list) Console.WriteLine(num);
                }
            }
            else
            {
                Console.WriteLine("Input must be within the range of [1, 100]");
            }
        }
    }
}

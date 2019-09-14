using System;
using System.Collections.Generic;

namespace ITOlympics2019
{
    public static class Average1
    {
        public static void Do()
        {
            string problem = @"Average Problem #1:
            Do the FLAME(Friends-Lovers-Affection-Marriage-Enemies)
            on two input string names.";
            Console.WriteLine(problem);

            Console.WriteLine("Input first name:");
            string a = Console.ReadLine();

            Console.WriteLine("Input second name:");
            string b = Console.ReadLine();

            //Convert both strings to lowercase for more accurate matching
            a = a.ToLower();
            b = b.ToLower();

            //Convert both strings to char array
            char[] _a = a.ToCharArray();
            char[] _b = b.ToCharArray();

            //Make a List out of the char array
            List<char> list_a = new List<char>(_a);
            List<char> list_b = new List<char>(_b);

            //Create a temp list that will store the character marked for duplicate-checking
            //We will use List because of the useful Contains method
            //NOTE: we should not remove any element in the list WHILE
            //we are iterating in it because that will lead to shifting of elements
            //and thus will lead to undesired behaviours. We will set the value to 0
            //first and then remove elements with value of 0 at the end for safety
            //that is why we need to have this temp list.

            List<char> temp = new List<char>();

            //Go over each character in the first list
            foreach(char ch_a in list_a)
            {
                //Go over each character in the second list
                foreach(char ch_b in list_b)
                {
                    //Check if the current character in list_a is the
                    //same as the current character in list_b
                    if (ch_a.Equals(ch_b))
                        //Store the matching character to the temp list
                        temp.Add(ch_a);
                }
            }

            //Do the removing here of the matching characters in both list
            foreach(char ch in temp)
            {
                list_a.RemoveAll((obj) => obj.Equals(ch));
                list_b.RemoveAll((obj) => obj.Equals(ch));
            }

            //Get the remaining letters count from both list
            int rem = list_a.Count + list_b.Count;

            //Make a char array of 'flame'
            //We need array for indexing each letter
            //0 - f, 1 - l, 2 - a, 3 - m, 4 - e
            char[] flame = "flame".ToCharArray();

            //Calculate the position in the `flame` char array using
            //the modulo operator. Subtract by 1 since arrays are 0-based index
            char pos = flame[(rem % flame.Length) - 1];

            //Properly display the output depending on the pos
            switch (pos)
            {
                case 'f': Console.WriteLine("Friends"); break;
                case 'l': Console.WriteLine("Lovers"); break;
                case 'a': Console.WriteLine("Affection"); break;
                case 'm': Console.WriteLine("Marriage"); break;
                case 'e': Console.WriteLine("Enemies"); break;
            }
        }
    }
}

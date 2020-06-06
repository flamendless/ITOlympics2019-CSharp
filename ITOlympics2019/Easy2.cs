using System;
using System.Collections.Generic;
using System.Text;

namespace ITOlympics2019
{
    public static class Easy2
    {
        public static void Do()
        {
            string problem = @"Easy Problem #2:
            Remove all duplicates in the string.
            Remove all spaces, numbers, and special characters in the string.
            Convert all character in the string to lowercase.
            Then add all the ASCII value of the modified string
            ";
            Console.WriteLine(problem);

            Console.WriteLine("Input a string:");
            string input = Console.ReadLine();

            //Convert all characters in the string to lowercase
            input = input.ToLower();

            //Convert the string to a char array so we can easily iterate over each character
            char[] orig = input.ToCharArray();

            //Create a list that will contain the duplicate character
            //We will use List because it has the Contains method
            List<char> temp = new List<char>();

            //Use StringBuilder for optimized editing of string
            StringBuilder str = new StringBuilder();

            //Go over each character in the string
            foreach (char ch in orig)
            {
                //Only process the character if it is NOT number, special character, space, and so on.
                //Check if the temp list contains already the character (for duplicates)
                //This will make sure that we are only going to get a string with no duplicate
                if (!temp.Contains(ch) && char.IsLetter(ch))
                {
                    temp.Add(ch); //Add the character to the temp list
                    str.Append(ch); //Append the character to the StringBuilder
                }
            }

            //Convert the string to byte array
            Byte[] bytes = Encoding.ASCII.GetBytes(str.ToString());

            //This will store the sum of the ASCII value of each character
            int sum = 0;
            foreach (Byte b in bytes)
                sum += b;

            //Convert the integer sum to its binary representation
            string binary = Convert.ToString(sum, 2);

            //Display the binary
            Console.WriteLine(binary);
        }
    }
}

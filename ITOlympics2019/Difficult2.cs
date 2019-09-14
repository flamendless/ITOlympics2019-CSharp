using System;
using System.Collections.Generic;
using System.Text;

namespace ITOlympics2019
{
    public static class Difficult2
    {
        public static void Do()
        {
            string problem = @"Difficult Problem #2:
            Do the Vigenere cipher on the input string.

            Constraints:
                input text must be a string
                input key must be a string
                key must not exceed the text length
                ";
            Console.WriteLine(problem);

            Console.WriteLine("Input text string:");
            string text = Console.ReadLine();

            Console.WriteLine("Input key string:");
            string key = Console.ReadLine();

            bool text_valid = true;
            bool key_valid = true;

            //Make text input only contains valid characters and/or spaces
            foreach (char ch in text.ToCharArray())
            {
                if (!(char.IsLetter(ch) || char.IsSeparator(ch)))
                {
                    text_valid = false;
                    break;
                }
            }

            //Make key input only contains valid characters and/or spaces
            foreach (char ch in key.ToCharArray())
            {
                if (!(char.IsLower(ch) || !char.IsSeparator(ch)))
                {
                    key_valid = false;
                    break;
                }
            }

            //If text and key inputs are valid
            if (key_valid && text_valid)
            {
                //Convert both input to uppercase
                text = text.ToUpper();
                key = key.ToUpper();

                //Create a temp list from the text input
                List<char> temp = new List<char>(text);

                //Remove the whitespaces in the temp list
                temp.RemoveAll((obj) => char.IsSeparator(obj));

                //Create a char array from the temp list
                char[] new_text = new char[temp.Count];
                for (int i = 0; i < new_text.Length; i++)
                    new_text[i] = temp[i];

                //Do a cyclic filling up of the key so that its length is equal to the length of the text input
                if (key.Length < new_text.Length)
                {
                    int current = 0;
                    while (true)
                    {
                        if (new_text.Length == current)
                            current = 0;
                        if (key.Length == new_text.Length)
                            break;
                        key += key[current];
                        current++;
                    }
                }

                //Use a StringBuilder for optimization than string since we are going to modify the variable many times.
                StringBuilder cipher = new StringBuilder();

                //Cipher the new_text using the key
                for (int i = 0; i < new_text.Length; i++)
                {
                    //Add the value of new_text[i] and key[i] and then modulo by 26 (number of letters in the alphabet)
                    //NOTE: we convert the value to an int implicitly
                    int n = (new_text[i] + key[i]) % 26;

                    //Add the value of capital A to the variable because vignere operates on uppercase
                    n += 'A';

                    //Append to the StringBuilder the implicit-casted value of integer n to char
                    cipher.Append((char) n);
                }

                //Re-insert the whitespaces to the ciphered text so that it will match with the text input
                for (int i = 0; i < text.Length; i++)
                {
                    char ch = text[i];
                    if (char.IsSeparator(ch))
                    {
                        cipher.Insert(i, ' ');
                    }
                }

                //Display the ciphered text
                Console.WriteLine(cipher);
            }
            else
                Console.WriteLine("Input for key and string must be a string");
        }
    }
}

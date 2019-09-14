using System;
using System.Collections.Generic;

namespace ITOlympics2019
{
    public static class Average2
    {
        public static void Do()
        {
            string problem = @"Average Problem #2:
            Create a randomly generated strong password.

            Constraints:
                8 - 24 characters
                Must contain atleast one lowercase, one uppercase, one number, and one special character
                Must not use similar looking characters like I, l, 1, 0, O
            ";

            Console.WriteLine(problem);

            Console.WriteLine("Input length of password:");
            int n;
            int min = 8;
            int max = 24;

            //Try to parse the input to integer
            if (int.TryParse(Console.ReadLine(), out n))
            {
                //Check for negative and boundary constraints
                if (n < 0 || n < min || n > max)
                    Console.WriteLine("Input must be positive and within the range of [{0}, {1}]", min, max);
                else
                {
                    //Create a char array that will store the generated password
                    char[] password = new char[n];

                    //Create the following possible and valid characters
                    string valid_lowercase = "abcdefghjkmnpqrstuvwxyz";
                    string valid_uppercase = valid_lowercase.ToUpper();
                    string valid_number = "012345678910";
                    string valid_special = "!@#$%^&*()_+=-";

                    //Create a list that will contain all of the possible and valid characters
                    List<char> valid = new List<char>();

                    //Add all possible and valid lowercase character to the list
                    foreach (char ch in valid_lowercase.ToCharArray())
                        valid.Add(ch);

                    //Add all possible and valid uppercase character to the list
                    foreach (char ch in valid_uppercase.ToCharArray())
                        valid.Add(ch);

                    //Add all possible and valid number character to the list
                    foreach (char ch in valid_number.ToCharArray())
                        valid.Add(ch);

                    //Add all possible and valid special character to the list
                    foreach (char ch in valid_special.ToCharArray())
                        valid.Add(ch);

                    //Make a random generator object
                    Random random = new Random();

                    //This will keep track of the index in the password char array
                    int current = 0;

                    //For constraints checking
                    bool has_lowercase = false;
                    bool has_uppercase = false;
                    bool has_number = false;
                    bool has_special = false;

                    //If one of the constraints is not met, repeat the random password generation until all check passes
                    while (!has_lowercase || !has_uppercase || !has_special || !has_number)
                    {
                        //Continue generating a random character from the list until we fill the length of password required
                        while (current != n)
                        {
                            //Get a random index from the valid list
                            int random_i = random.Next(valid.Count);

                            //Get the char element in the valid list with the randomly selected index
                            char random_char = valid[random_i];

                            //NOTE that in number and special char checking, we group the conditions that uses the || (or) syntax so that
                            //it will not conflict with the && (and) condition
                            //Check if the current character is lowercase AND if we still do not have a lowercase character
                            if (char.IsLower(random_char) && !has_lowercase)
                                has_lowercase = true; //Set the flag to true to avoid future checking since we already have one lowercase character

                            //Check if the current character is uppercase AND if we still do not have a uppercase character
                            else if (char.IsUpper(random_char) && !has_uppercase)
                                has_uppercase = true; //Set the flag to true to avoid future checking since we already have one uppercase character

                            //Check if the current character is either a number or a digit AND if we still do not have a number or a digit character
                            //NOTE: digit is 0 to 9 while number varies according to locale
                            else if ((char.IsNumber(random_char) || char.IsDigit(random_char)) && !has_number)
                                has_number = true; //Set the flag to true to avoid future checking since we already have one number character

                            //Check if the current character is special AND if we still do not have a special character
                            //NOTE: special characters include symbols and punctuations.
                            //Check type with `char.GetUnicodeCategory(ch)` for more info
                            else if ((char.IsSymbol(random_char) || char.IsPunctuation(random_char)) && !has_special)
                                has_special = true; //Set the flag to true to avoid future checking since we already have one special character

                            //Store that random char to the password char array
                            password[current] = random_char;

                            //Increment the index counter
                            current++;
                        }
                    }

                    //Display the randomly generated strong password
                    Console.WriteLine(password);
                }
            }
            else
                Console.WriteLine("Input must be a number");
        }
    }
}

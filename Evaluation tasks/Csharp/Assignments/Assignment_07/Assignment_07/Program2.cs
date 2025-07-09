using System;
using System.Collections.Generic;

namespace Assignment_07
{
    internal class Program2
    {
        static void Main()
        {
            Console.WriteLine("Enter the string");
            string input = Console.ReadLine();

            string[] lettersArray = input.Split(',');

            List<string> stringWord = new List<string>();

            foreach (string word in lettersArray)
            {
                string trim = word.Trim().ToLower();

                if (trim.StartsWith("a") && trim.EndsWith("m"))
                {
                    stringWord.Add(trim);
                }
            }

            Console.WriteLine("The words are :");
            foreach (string word in lettersArray)
            {
                Console.WriteLine(word);
            }
            Console.Read();
        }
    }
}

                
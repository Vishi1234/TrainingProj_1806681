using System;
using System.Linq;


namespace Assignment2
{
    internal class StringProg2
    {
        public static void Reverse_of_string()
        {
            Console.WriteLine("Enter the word/string");
            string word = Console.ReadLine();
            char[] charword = word.ToCharArray();
            Array.Reverse(charword);

            string reversestring = new string(charword);
            
            Console.WriteLine(reversestring);
            Console.ReadLine();


        }
    }
}

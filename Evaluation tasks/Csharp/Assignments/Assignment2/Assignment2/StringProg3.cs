﻿using System;


namespace Assignment2
{
    internal class StringProg3
    {
        public static void Equal_String()
        {
            Console.WriteLine("enter 1st word/string");
            string word1 = Console.ReadLine();
            Console.WriteLine("enter 2nd word/string");
            string word2 = Console.ReadLine();
            bool ans = word1.Equals(word2);
            Console.WriteLine("{0}", ans);

            Console.ReadLine();
        }
    }
}

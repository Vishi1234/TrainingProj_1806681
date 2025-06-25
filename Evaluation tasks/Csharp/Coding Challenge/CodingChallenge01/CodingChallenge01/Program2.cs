using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge01
{
        class Reverse
        {
            public static void Prog2()
            {
                Console.WriteLine("enter the string");
                string word = Console.ReadLine();
                char[] arr = word.ToCharArray();
                char first_char = arr[0], last_char = arr[arr.Length-1];
                arr[0] = last_char;
                arr[arr.Length - 1] = first_char;

                string word2 = new string(arr);
            Console.WriteLine(word2);
            Console.ReadLine();
            }
        }
        internal class Program2
        {
            public static void Main()
            {
                Reverse.Prog2();
            }
        }
    

}

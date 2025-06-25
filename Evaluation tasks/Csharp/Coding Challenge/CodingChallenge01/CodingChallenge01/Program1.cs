using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge01
{

    class String
    {
        public static void Prog1()
        {
            Console.WriteLine("Enter the string");
            string word = Console.ReadLine();
            Console.WriteLine("Enter the position");
            int position = Convert.ToInt32(Console.ReadLine());
            if (position < 0 || position >= word.Length)
            {
                Console.WriteLine("invalid position");
                return;
            }
            string result = word.Remove(position, 1);
            Console.WriteLine(result);
        }
    }
    internal class Program1
    {
        static void Main(string[] args)
        {
            String.Prog1();
        }
    }
}

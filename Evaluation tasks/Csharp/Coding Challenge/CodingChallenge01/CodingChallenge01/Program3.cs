using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge01
{
    class Max
    {
        public static void Prog3()
        {
            Console.WriteLine("Enter 3 numbers");
            string[] input = Console.ReadLine().Split(',');
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int c = int.Parse(input[2]);

            int largestNum;

            if (a > b && a > c)
            {
                largestNum = a;
            }
            else if (b > c && b > a)
            {
                largestNum = b;
            }
            else
            {
                largestNum = c;
            }
            Console.WriteLine(largestNum);

        }
    }

    internal class Program3
    {
        public static void Main()
        {
            Max.Prog3();
        }
        
    }
  
}

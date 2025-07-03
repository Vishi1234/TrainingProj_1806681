using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_02
{
    internal class Program3 
    {
        public static void CheckNum(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Negative numbers not allowed");
            }
            else
            {
                Console.WriteLine("valid number");
            }
        }

        public static void Main()
        {
            Console.WriteLine("enter the number");
            string number = Console.ReadLine();

            try
            {
                int num = int.Parse(number);
                CheckNum(num);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}

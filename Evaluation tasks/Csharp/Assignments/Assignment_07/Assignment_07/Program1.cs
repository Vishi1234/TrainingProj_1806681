using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07
{
    internal class Program1
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers separated by commas :");
            string input = Console.ReadLine();

            string[] inputParts = input.Split(',');
            int[] numbers = new int[inputParts.Length];

            for (int i = 0; i < inputParts.Length; i++)
            {
                numbers[i] = int.Parse(inputParts[i].Trim());
            }

            Console.WriteLine("Numbers and their squares:");
            foreach (int number in numbers)
            {
                int square = number * number;
                if (square > 20)
                {
                    Console.WriteLine($"The sqaure of {number} is {square}");
                }
            }
            Console.Read();
        }
    }
}



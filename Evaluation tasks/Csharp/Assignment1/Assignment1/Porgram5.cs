using System;
using System.IO.Pipes;


namespace Assignment1
{
    internal class Porgram5
    {
        public static void Sum_Triple_Integer()
        {
            Console.WriteLine("Enter the 1st number");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the 2nd number");
            int b = Convert.ToInt32(Console.ReadLine());
            int add = a + b;

            if (a == b)
            {
                int triple = 3 * add;
                Console.WriteLine("The triple of the sum is" + " " + triple);
            }
            else
            {
                Console.WriteLine("The sum is" + " " + add);
            }

            Console.ReadLine();

        }

    }
}

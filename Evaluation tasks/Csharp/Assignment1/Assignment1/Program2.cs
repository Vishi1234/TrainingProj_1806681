using System;


namespace Assignment1
{
    internal class Program2
    {
        public static void Check_Positivity()
        {
            Console.WriteLine("Enter the number");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num > 0)
                Console.WriteLine("{0} is a positive number", num);
            else
                Console.WriteLine("{0} is a negative number", num);

            Console.ReadLine();

        }
    }
}

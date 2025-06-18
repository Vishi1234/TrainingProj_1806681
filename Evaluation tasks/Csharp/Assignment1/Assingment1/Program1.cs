using System;


namespace Assingment1
{
    internal class Program1
    {
        public static void Positivity_Check()
        {
            Console.WriteLine("Ques : Checking the positivity of a number");
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

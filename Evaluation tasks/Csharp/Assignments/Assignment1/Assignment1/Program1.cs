using System;


namespace Assignment1
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Equal_or_not();
            Program2.Check_Positivity();
            Program3.Operation_Perform();
            Program4.Multiplication_Tble();
            Porgram5.Sum_Triple_Integer();
        }

        public static void Equal_or_not()
        {
            Console.WriteLine("Enter 1st number");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd number");
            int b = Convert.ToInt32(Console.ReadLine());

            if (a == b)
                Console.WriteLine("{0} and {1} are equal", a, b);
            else
                Console.WriteLine("{0} and {1} are not equal", a, b);

            Console.ReadLine();

        }
    }
}

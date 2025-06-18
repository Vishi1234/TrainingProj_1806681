using System;


namespace Assingment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.comparison_Num();
            Console.ReadLine();
            Program1.Positivity_Check();
           
        }

        public void comparison_Num()
        {
            Console.WriteLine("Ques : Check if the numbers are equal or not");
            Console.WriteLine("Enter 1st number");
            int a;
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd number");
            int b;
            b = Convert.ToInt32(Console.ReadLine());

            if (a == b)
                Console.WriteLine("{0} and {1} are equal", a, b);
            else
                Console.WriteLine("{0} and {1} are not equal", a, b);
        }
    }
}

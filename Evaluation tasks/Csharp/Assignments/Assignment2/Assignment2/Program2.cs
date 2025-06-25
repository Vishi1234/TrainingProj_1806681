using System;


namespace Assignment2
{
    internal class Program2
    {
        public static void Four_Times()
        {
            Console.WriteLine("Enter the number");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0} {0} {0} {0}",num);
            Console.WriteLine("{0}{0}{0}{0}", num);
            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.Write("{0}{0}{0}{0}", num);

            Console.ReadLine();
        }
    }
}

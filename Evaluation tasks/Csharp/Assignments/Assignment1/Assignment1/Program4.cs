using System;


namespace Assignment1
{
    internal class Program4
    {
        public static void Multiplication_Tble()
        {
            Console.WriteLine("Enter the number");
            int num = Convert.ToInt32 (Console.ReadLine());

            int ans = 0;

            for (int i = 0; i<=10; i++)
            {
                ans = num * i;
                Console.WriteLine("{0} * {1} = {2}", num, i, ans);
                
            }
            Console.ReadLine();
        }
    }
}

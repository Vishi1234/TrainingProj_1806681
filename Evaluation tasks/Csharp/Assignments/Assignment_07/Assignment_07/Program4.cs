using System;

namespace Assignment_07
{
    public class Calculation
    {
        public string CalculateConcession(int age, double totalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double discountedFare = totalFare * 0.70;
                return $"Senior Citizen - {discountedFare}";
            }
            else
            {
                return $"Print Ticket Booked - {totalFare}";
            }
        }
    }
    class Program4
    {
        private const double TotalFare = 500;

        static void Main()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Calculation calculate = new Calculation();
            string result = calculate.CalculateConcession(age, TotalFare);

            Console.WriteLine($"Passenger is {name}");
            Console.WriteLine($"Result is {result}");
            Console.Read();
        }
    }
}

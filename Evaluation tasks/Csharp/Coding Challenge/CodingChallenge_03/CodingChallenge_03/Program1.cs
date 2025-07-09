using System;

namespace CodingChallenge_03
{

    class CricketTeam
    {
        public int PointsCalculation(int number_of_match)
        {
            int[] scores = new int[number_of_match];
            int sum = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine("Enter the score of the match");
                scores[i] = Convert.ToInt32(Console.ReadLine());
                sum += scores[i];
            }

            int avg = sum / number_of_match;

            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine($"The average is {avg}");
            Console.WriteLine($"The count of matches is {number_of_match}");

            return avg;

        }
    }
    internal class Program1
    {
        public static void Main()
        {
            Console.Write("Enter the number of matches: ");
            int number_of_match = Convert.ToInt32(Console.ReadLine());

            CricketTeam ct = new CricketTeam();
            ct.PointsCalculation(number_of_match);
            Console.ReadLine();
        }
    }
}

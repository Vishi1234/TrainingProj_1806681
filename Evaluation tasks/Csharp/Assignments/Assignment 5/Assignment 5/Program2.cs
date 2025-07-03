using System;


namespace Assignment_5
{

    public class InvalidMarksException : Exception
    {
        public InvalidMarksException(string message) : base(message) { }
    }

    class Scholarship
    {
        public double Merit(double marks, double fees)
        {
            double scholarAmt;
            if (marks >= 70 && marks <= 80)
            {
                scholarAmt = 0.2 * fees;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarAmt = 0.3 * fees;
            }
            else if (marks > 90 && marks <= 100)
            {
                scholarAmt = 0.5 * fees;
            }
            else
            {
                throw new InvalidMarksException("Marks should be between 70 and 100.");
            }

            return scholarAmt;
        }
    }
    internal class Program2
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter the marks obtained");
                double marks = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter your fees");
                double fees = Convert.ToDouble(Console.ReadLine());

                Scholarship scholar = new Scholarship();
                double Amt = scholar.Merit(marks, fees);

                Console.WriteLine("Scholarship amount is : " + Amt);
                Console.ReadLine();
            }
            catch (InvalidMarksException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter valid numeric input : " + ex.Message);
            }



        }
    }
}

using System;
using System.IO;

namespace Assignment_06
{
    internal class Program2
    {
        static void Main()
        {
            string[] lines = {
            "Hi people",
            "This is Bangalore",
            "This is Assignment 6",
            "This is Program2",
        };

            string filePath = "EmployeesList.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine("File created and data written");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }
    }
}
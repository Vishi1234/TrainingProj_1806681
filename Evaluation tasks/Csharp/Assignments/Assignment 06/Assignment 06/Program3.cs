using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_06
{
    internal class Program3
    {
        static void Main()
        {
            string filePath = "EmployeesList.txt";
            try
            {
                int lineCount = File.ReadAllLines(filePath).Length;

                Console.WriteLine($"The file contains {lineCount} lines.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }
    }
}

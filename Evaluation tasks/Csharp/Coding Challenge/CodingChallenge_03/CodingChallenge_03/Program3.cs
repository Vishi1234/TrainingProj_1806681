using System;
using System.IO;
namespace CodingChallenge_03
{
        class Program3
        {
            static void Main()
            {
                string filePath = "cricket_scores.txt"; 

                Console.WriteLine("Enter the text that is to be appended");
                string contentToAppend = Console.ReadLine();

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(contentToAppend);
                    }

                    Console.WriteLine($"Text appended successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error {ex.Message}");
                }
            }
        }
    }


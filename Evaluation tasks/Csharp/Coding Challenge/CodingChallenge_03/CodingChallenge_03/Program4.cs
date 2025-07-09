using System;

namespace CodingChallenge_03
{
        class Program4
        {
            public delegate int CalculationDeleg(int a, int b);

            public static int Add(int a, int b)
            {
                return a + b;
            }

            public static int Subtract(int a, int b)
            {
                return a - b;
            }

            public static int Multiply(int a, int b)
            {
                return a * b;
            }

            public static void Calculator_Operation(string operationNeed, CalculationDeleg operation, int num1, int num2)
            {
                int result = operation(num1, num2);
                Console.WriteLine($"{num1} {operationNeed} {num2} = {result}");
            }

            static void Main()
            {
                Console.WriteLine("Enter the number 1");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the number 2");
                int num2 = Convert.ToInt32(Console.ReadLine());

                Calculator_Operation("Sum is", Add, num1, num2);
                Calculator_Operation("Subtraction is", Subtract, num1, num2);
                Calculator_Operation("Multiplication is", Multiply, num1, num2);
            Console.ReadLine();
            }
        }
    }


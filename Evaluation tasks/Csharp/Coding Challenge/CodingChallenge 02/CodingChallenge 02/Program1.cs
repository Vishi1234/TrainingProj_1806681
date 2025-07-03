using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_02
{
    public abstract class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Grade { get; set; }


        public abstract bool IsPassed(int grade);

    }
    public class Undergraduate : Student
    {
        public override bool IsPassed(int grade)
        {
            return grade > 70.0;
        }
    }

    public class Graduate : Student
        {
        public override bool IsPassed(int grade)
        {
            return grade > 80.0;
        }
        }

        internal class Porgram1
    {
        public static void Main()
        {
           
            Console.WriteLine("Enter student id");
            int StudentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter student name");
            string StudentName = Console.ReadLine();
            Console.WriteLine("enter the grade");
            int grade = Convert.ToInt32(Console.ReadLine());

            Undergraduate ug = new Undergraduate
            {
                StudentId = StudentId,
                StudentName = StudentName,
                Grade = grade
            };

            Graduate grad = new Graduate
            {
                StudentId = StudentId,
                StudentName = StudentName,
                Grade = grade
            };

            Console.WriteLine($" Ug Passed? {ug.IsPassed(ug.Grade)}");
            Console.WriteLine($" Grad Passed? {grad.IsPassed(grad.Grade)}");

            Console.ReadLine();

        }
    }


    }


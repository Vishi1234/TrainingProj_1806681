using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Student
    {
        private int rollno;
        private string name;
        private string studentclass;
        private int semester;
        private string branch;
        private int[] marks = new int[5];

        public Student(int rollno, string name, string studentclass, int semester, string branch)
        {
            this.rollno = rollno;
            this.name = name;
            this.studentclass = studentclass;
            this.semester = semester;
            this.branch = branch;
        }

        public void GetMarks()
        {
            Console.WriteLine("enter the marks");
            for (int i = 0; i < 5; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            int sum = 0;
            bool isFailed = false;
            foreach (int i in marks)
            {
                if (i < 35)
                {
                    isFailed = true;
                    break;
                }
                sum = sum + i;
            }

            double avg = sum / marks.Length;

            if (isFailed || avg < 50)
            {
                Console.WriteLine("FAILED");
            }
            else
            {
                Console.WriteLine("PASSED");
            }
        }

        public void DisplayData()
        {
            Console.WriteLine($"Roll no.: {rollno}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"class {studentclass}");
            Console.WriteLine($"Roll no.: {rollno}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Subject {i + 1} : {marks[i]}");

            }
        }
        internal class Program2
        {
            static void Main()
            {
                Console.WriteLine("enter roll no");
                int rollno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter name");
                string name = Console.ReadLine();
                Console.WriteLine("enter class");
                string studentclass = Console.ReadLine();
                Console.WriteLine("enter semester");
                int semester = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter branch");
                string branch = Console.ReadLine();


                Student s = new Student(rollno, name, studentclass, semester, branch);
                s.GetMarks();
                s.DisplayResult();
                s.DisplayData();
                Console.ReadLine();
            }

        }
    }
}

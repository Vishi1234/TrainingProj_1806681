using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04
{

    class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;

        public void Display()
        {
            Console.WriteLine("ID: " + Id + ", Name: " + Name + ", Department: " + Department + ", Salary: ₹" + Salary);
        }
    }
    internal class Program1
    {
        static List<Employee> employees = new List<Employee>();

        static void Main()
        {
            int choice;

            do
            {
                Console.Write("Choice: ");

                string input = Console.ReadLine();
                bool parsed = int.TryParse(input, out choice);
                if (!parsed)
                {
                    Console.WriteLine("Invalid input. Enter a number.");
                    continue;
                }

                if (choice == 1)
                    Add();
                else if (choice == 2) 
                    View();
                else if (choice == 3)
                    Search();
                else if (choice == 4) 
                    Update();
                else if (choice == 5)
                    Delete();
                else if (choice != 6) Console.WriteLine("Choose a valid option.");
            } while (choice != 6);
        }
        static void Add()
        {
            try
            {
                Console.Write("Enter id ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Name");
                string name = Console.ReadLine();
                Console.Write("Enter the Department");
                string dept = Console.ReadLine();
                Console.Write("Enter the salary");
                double sal = Convert.ToDouble(Console.ReadLine());

                Employee emp = new Employee();
                emp.Id = id;
                emp.Name = name;
                emp.Department = dept;
                emp.Salary = sal;
                employees.Add(emp);
                Console.WriteLine("Employee added.");
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        static void View()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            for (int i = 0; i < employees.Count; i++)
            {
                employees[i].Display();
            }
        }

        static void Search()
        {
            Console.Write("Enter ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    employees[i].Display();
                    found = true;
                    break;
                }
            }

            if (!found) Console.WriteLine("Not found.");
        }

        static void Update()
        {
            Console.Write("Enter ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    Console.Write("New Name: ");
                    employees[i].Name = Console.ReadLine();
                    Console.Write("New Department: ");
                    employees[i].Department = Console.ReadLine();
                    Console.Write("New Salary: ");
                    employees[i].Salary = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Updated.");
                    found = true;
                    break;
                }
            }

            if (!found) Console.WriteLine("Employee not found.");
        }

        static void Delete()
        {
            Console.Write("Enter ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            bool deleted = false;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    employees.RemoveAt(i);
                    Console.WriteLine("Deleted.");
                    deleted = true;
                    break;
                }
            }

            if (!deleted) Console.WriteLine("Employee not found.");
        }
    }
}




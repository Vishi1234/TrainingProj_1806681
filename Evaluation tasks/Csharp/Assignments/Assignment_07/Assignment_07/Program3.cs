using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public int EmpSalary { get; set; }
    }

    class Program3
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            Console.Write("Enter the number of employees: ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter details for Employee {i + 1}:");

                Console.WriteLine("Enter the Employee id");
                int empId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the employee name");
                string empName = Console.ReadLine();

                Console.WriteLine("Enter the employee city");
                string empCity = Console.ReadLine();

                Console.WriteLine("Enter the employee salary");
                int empSalary = int.Parse(Console.ReadLine());

                employees.Add(new Employee
                {
                    EmpId = empId,
                    EmpName = empName,
                    EmpCity = empCity,
                    EmpSalary = empSalary
                });
            }

            Console.WriteLine("List of all Employees");
            foreach (var emp in employees)
                DisplayEmployee(emp);

            Console.WriteLine("Employees with Salary > 45000");
            foreach (var emp in employees.Where(e => e.EmpSalary > 45000))
                DisplayEmployee(emp);

            Console.WriteLine("Employees from Bangalore");
            foreach (var emp in employees.Where(e => e.EmpCity.Equals("Bangalore")))
                DisplayEmployee(emp);

            Console.WriteLine("Employees sorted by Name");
            foreach (var emp in employees.OrderBy(e => e.EmpName))
                DisplayEmployee(emp);

            Console.ReadLine();
        }

        static void DisplayEmployee(Employee emp)
        {
            Console.WriteLine($"ID is {emp.EmpId}, Name is {emp.EmpName}, City is {emp.EmpCity}, Salary is {emp.EmpSalary}");
        }
    }
}

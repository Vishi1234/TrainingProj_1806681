using System;
using System.Data;
using System.Data.SqlClient;

namespace CodingChallenge6
{
    internal class Program
    {
        public static void Main()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=InifniteDB;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("EmployeesOp", con);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Enter Employee ID:");
            int empidd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Salary:");
            int salary = Convert.ToInt32(Console.ReadLine());

            cmd.Parameters.AddWithValue("@empid", empidd);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@salary", salary);


            SqlParameter outputsalary = new SqlParameter("@updatedsal", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputsalary);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("EmpId: " + empidd);
                Console.WriteLine("Name:" + name);
                Console.WriteLine("Salary:" + salary);
                Console.WriteLine("Updated salary:" + outputsalary.Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            Console.ReadLine();
        }
    }
}



using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System
{
    internal class UserOperations
    {
        private static string ToCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(input.ToLower());
        }
        public static void AddUser()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("RegisterCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Add user");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Welcome! Please enter the following details to add an user");
            Console.WriteLine();
            Console.Write("Enter Your First Name: ");
            string firstname = ToCase(Console.ReadLine());
            Console.Write("Enter Your Last Name: ");
            string lastname = ToCase(Console.ReadLine());
            Console.Write("Enter Gender: ");
            string gender = ToCase(Console.ReadLine());
            Console.Write("Enter phone: ");
            string phn = ToCase(Console.ReadLine());
            if (phn.Length != 10 || !phn.All(char.IsDigit))
            {
                Console.WriteLine("Invalid. Please enter a 10-digit number.");
                return;
            }
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            if (!email.Contains("@"))
            {
                Console.WriteLine("You have missed @. Please enter a valid email address.");
                return;
            }
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            cmd.Parameters.AddWithValue("@fname", firstname);
            cmd.Parameters.AddWithValue("@lname", lastname);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@phone", phn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pass", password);

            SqlParameter outputid = new SqlParameter("@generatedid", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputid);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("**********************************");
                Console.WriteLine();
                Console.WriteLine("Your user is added successful!!");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("|         Field         |       Value         |");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("| Customer ID           | " + outputid.Value + "                       ");
                Console.WriteLine("| First Name            | " + firstname + "                   ");
                Console.WriteLine("| Last Name             | " + lastname + "           ");
                Console.WriteLine("| Gender                | " + gender + "           ");
                Console.WriteLine("| Phone Number          | " + phn + "           ");
                Console.WriteLine("| Email                 | " + email + "           ");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
              
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

        public static void UpdateUser()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Update user details");
            Console.WriteLine("-------------------------------");
            Console.Write("Enter User Id to update:");
            int userID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Gender");
            Console.WriteLine("4. Phone");
            Console.WriteLine("5. Email");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            string column = "", newValue = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            switch (choice)
            {
                case 1:
                    column = "UserFName";
                    Console.Write("Enter new first name: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE CUSTOMER_TABLE SET FirstName = @value WHERE CustID = @userID";
                    break;
                case 2:
                    column = "UserLName";
                    Console.Write("Enter last name: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE CUSTOMER_TABLE SET LastName = @value WHERE CustID = @userID";
                    break;
                case 3:
                    column = "Gender";
                    Console.Write("Enter gender: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE CUSTOMER_TABLE SET Gender = @value WHERE CustID = @userID";
                    break;
                case 4:
                    column = "Phno";
                    Console.Write("Enter new phone number: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE CUSTOMER_TABLE SET Phone = @value WHERE CustID = @userID";
                    break;
                case 5:
                    column = "Email";
                    Console.Write("Enter new email: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE CUSTOMER_TABLE SET Email = @value WHERE CustID = @userID";
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            cmd.Parameters.AddWithValue("@value", newValue);
            cmd.Parameters.AddWithValue("@userID", userID);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("**********************************");
                Console.WriteLine();
                Console.WriteLine("User details are updated successfully!!");


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

        public static void DeleteUser()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Delete user");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Enter user ID to delete:");
            int userID = Convert.ToInt32(Console.ReadLine());

            SqlCommand deleteDetailsCmd = new SqlCommand("DELETE FROM CUSTOMER_TABLE WHERE CustID = @userID", con);
            deleteDetailsCmd.Parameters.AddWithValue("@userID", userID);
            try
            {
                con.Open();
                deleteDetailsCmd.ExecuteNonQuery();

                Console.WriteLine("**********************************");
                Console.WriteLine();
                Console.WriteLine("User details deleted successfully.");
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

        public static void ViewAllUsers()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMER_TABLE", con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15} {4,-15} {5,-12}",
                                  "User_ID", "First_Name", "Last_Name", "Gender", "Phone", "Email");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15} {4,-10} {5,-12}",
                        reader["CustID"],
                        reader["FirstName"],
                        reader["LastName"],
                        reader["Gender"],
                        reader["Phone"],
                        reader["Email"]);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}

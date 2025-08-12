using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace Railway_Reservation_System
{
    public class Register
    {
        private static string ToCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(input.ToLower());
        }
        public static void RegisterUser()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("RegisterCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Registration");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Welcome! Please enter the following details to register");
            Console.WriteLine();
            Console.Write("Enter Your First Name: ");
            string firstname = ToCase(Console.ReadLine());
            Console.Write("Enter Your Last Name: ");
            string lastname = ToCase(Console.ReadLine());
            Console.Write("Enter Gender: ");
            string gender = ToCase(Console.ReadLine());
            string phn;
            while (true)
            {
                Console.Write("Enter phone: ");
                phn = ToCase(Console.ReadLine());

                if (phn.Length == 10 && phn.All(char.IsDigit))
                {
                    break; 
                }

                Console.WriteLine("Invalid. Please enter a 10-digit number.");
            }

            string email;
            while (true)
            {
                Console.Write("Enter your email: ");
                email = Console.ReadLine();

                if (email.Contains("@"))
                {
                    break;
                }

                Console.WriteLine("You have missed '@'. Please enter a valid email address.");
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
                Console.WriteLine("Your registration is successful!!");
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
                Console.WriteLine("Do you want to login? (Yes or No)");
                string loginans = Console.ReadLine();
                if (loginans.ToLower() == "yes")
                {
                    UserLogin.LoginAsUser();
                }
                else
                {
                    return;
                }


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

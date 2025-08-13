using System;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation_System
{
    internal class UserLogin
    {
        public static string LoginUser(string email, string password)
        {
            string firstName = string.Empty;

            using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;"))
            using (SqlCommand cmd = new SqlCommand("LoginUser", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", password);

                SqlParameter outputParam = new SqlParameter("@fname", SqlDbType.VarChar, 30)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    firstName = outputParam.Value.ToString(); 
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

            return firstName;
        }
        public static void LoginAsUser()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("========= User Login ===========");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Enter your credentials to login");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            string loggedInEmail = email; 
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine();
            string firstName = LoginUser(email, password);

            if (!string.IsNullOrEmpty(firstName))
            {
                int custId = 0;
                using (SqlConnection conn = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;"))
                {
                    conn.Open();
                    SqlCommand getCustCmd = new SqlCommand("SELECT CustID FROM CUSTOMER_TABLE WHERE Email = @Email", conn);
                    getCustCmd.Parameters.AddWithValue("@Email", email);
                    custId = Convert.ToInt32(getCustCmd.ExecuteScalar());
                }

                Console.WriteLine($"Hi {firstName}, Welcome back!");
                Console.WriteLine();
                bool stayLoggedIn = true;

                while (stayLoggedIn)
                {
                    //Console.WriteLine();
                    Console.WriteLine("Please choose from below");
                    Console.WriteLine("1. Search Train by Number");
                    Console.WriteLine("2. Search Train by Name");
                    Console.WriteLine("3. View All Trains");
                    Console.WriteLine("4. Book a ticket");
                    Console.WriteLine("5. Cancel a ticket");
                    Console.WriteLine("6. View my Bookings");
                    Console.WriteLine("7. Download Ticket");
                    Console.WriteLine("8. Logout");
                    Console.WriteLine();
                    Console.Write("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            TrainByNum.GetTrainByNum();
                            break;
                        case 2:
                            TrainByName.GetTrainByName();
                            break;
                        case 3:
                            TrainOperations.ViewAllTrains();
                            break;
                        case 4:
                            Bookings.BookTrainByname(loggedInEmail);
                            break;
                        case 5:
                            CancelTicket.StartCancellationProcess();
                            break;
                        case 6:
                            MyBookings.ViewBookings(custId);
                            break;
                        case 7:
                            DownloadTicket.Downloading();
                            break;
                        case 8:
                            Console.WriteLine("Logging out....");
                            RegistrationOptions.Options();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.WriteLine();
                            break;

                    }
                }
            }
            else
            {
                Console.WriteLine("Login failed.");
                Console.WriteLine("Enter 'y' to try logging in again");
                char ans = Convert.ToChar(Console.ReadLine());

                if (ans == 'y' || ans == 'Y')
                {
                    UserLogin.LoginAsUser();
                }
            }
            Console.ReadLine();
        }
    }
}

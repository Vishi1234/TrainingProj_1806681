using System;
using System.Data;
using System.Data.SqlClient;


namespace Railway_Reservation_System
{
    internal class AdminLogin
    {
        public static string LoginAdmin(string email, string password)
        {
            string Admin_Name = string.Empty;

            using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;"))
            using (SqlCommand cmd = new SqlCommand("LoginAdmin", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", password);

                SqlParameter outputParam = new SqlParameter("@name", SqlDbType.VarChar, 30)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Admin_Name = outputParam.Value.ToString();
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

            return Admin_Name;
        }
        public static void LoginAsAdmin()
        {
            Console.WriteLine();
            Console.WriteLine("Enter your credentials to login");
            Console.WriteLine("Demo credentials : email: lakshmn@gmail.com, password: laksh1998");
            Console.WriteLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine();
            string Admin_Name = LoginAdmin(email, password);

            if (!string.IsNullOrEmpty(Admin_Name))
            {
               
                    Console.WriteLine($"Hi {Admin_Name}, Welcome back!");
                bool stayLoggedIn = true;

                while (stayLoggedIn)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Add trains");
                    Console.WriteLine("2. Edit Train Details");
                    Console.WriteLine("3. Soft Delete trains");
                    Console.WriteLine("4. View all trains");
                    Console.WriteLine("5. Reactivate Train");
                    Console.WriteLine("6. Add Users");
                    Console.WriteLine("7. Update Users");
                    Console.WriteLine("8. Delete Users");
                    Console.WriteLine("9. View all bookings");
                    Console.WriteLine("10. View User List");
                    Console.WriteLine("11. Logout");
                    Console.WriteLine();
                    Console.Write("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            TrainOperations.Addtrain();
                            break;
                        case 2:
                            TrainOperations.UpdateTrain();
                            break;
                        case 3:
                            TrainOperations.SoftDeleteTrain();
                            break;
                        case 4:
                            TrainOperations.ViewAllTrains();
                            break;
                        case 5:
                            TrainOperations.ReactivateTrain();
                            break;
                        case 6:
                            UserOperations.AddUser();
                            break;
                        case 7:
                            UserOperations.UpdateUser();
                            break;
                        case 8:
                            UserOperations.DeleteUser();
                            break;
                        case 9:
                            MyBookings.ViewAllBookings();
                            break;
                        case 10:
                            UserOperations.ViewAllUsers();
                            break;
                        case 11:
                            Console.WriteLine("Logging out....");
                            RegistrationOptions.Options();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again");
                            Console.WriteLine();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Login failed.");
            }
            Console.ReadLine();
        }
    }
}


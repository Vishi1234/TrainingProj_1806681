using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System
{
    internal class TrainOperations
    {

        private static string ToCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(input.ToLower());
        }

        public static void Addtrain()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("Add_trains", con);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Add trains");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Enter the details to add a train");
            Console.WriteLine();
            Console.Write("Enter train number: ");
            int trainum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter train name: ");
            string trainame = ToCase(Console.ReadLine());
            Console.Write("Enter source: ");
            string source = ToCase(Console.ReadLine());
            Console.Write("Enter destination: ");
            string destin = ToCase(Console.ReadLine());
            Console.Write("Enter class: ");
            string classs = ToCase(Console.ReadLine());
            Console.Write("Enter availability per class: ");
            int available = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter cost per seat: ");
            int costps = Convert.ToInt32(Console.ReadLine());

            cmd.Parameters.AddWithValue("@trainno", trainum );
            cmd.Parameters.AddWithValue("@trainname", trainame);
            cmd.Parameters.AddWithValue("@source", source);
            cmd.Parameters.AddWithValue("@destination", destin);
            cmd.Parameters.AddWithValue("@class", classs);
            cmd.Parameters.AddWithValue("@availability", available);
            cmd.Parameters.AddWithValue("@cost", costps);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("**********************************");
                Console.WriteLine();
                Console.WriteLine("Train is added successfully!!");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("|         Field         |       Value         |");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("| Train Number          | " + trainum + "                       ");
                Console.WriteLine("| Train Name            | " + trainame + "                   ");
                Console.WriteLine("| Source                | " + source + "           ");
                Console.WriteLine("| Destination           | " + destin + "           ");
                Console.WriteLine("| Class                 | " + classs + "           ");
                Console.WriteLine("| Availability          | " + available + "           ");
                Console.WriteLine("| Cost                  | " + costps + "           ");
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

        public static void UpdateTrain()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Update train details");
            Console.WriteLine("-------------------------------");
            Console.Write("Enter train number to update: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Train Name");
            Console.WriteLine("2. Source");
            Console.WriteLine("3. Destination");
            Console.WriteLine("4. Class");
            Console.WriteLine("5. Availability");
            Console.WriteLine("6. Cost");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            string column = "", newValue = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            switch (choice)
            {
                case 1:
                    column = "TrainName";
                    Console.Write("Enter new train name: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE TRAIN_INTRO SET Train_Name = @value WHERE Train_No = @trainNo";
                    break;
                case 2:
                    column = "Source";
                    Console.Write("Enter new source: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE TRAIN_INTRO SET Source = @value WHERE Train_No = @trainNo";
                    break;
                case 3:
                    column = "Destination";
                    Console.Write("Enter new destination: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE TRAIN_INTRO SET Destination = @value WHERE Train_No = @trainNo";
                    break;
                case 4:
                    column = "Class";
                    Console.Write("Enter new class: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE TRAIN_DETAILS SET Class = @value WHERE Train_No = @trainNo";
                    break;
                case 5:
                    column = "Availability";
                    Console.Write("Enter new availability: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE TRAIN_DETAILS SET Availability = @value WHERE Train_No = @trainNo";
                    break;
                case 6:
                    column = "Cost";
                    Console.Write("Enter new cost per seat: ");
                    newValue = ToCase(Console.ReadLine());
                    cmd.CommandText = "UPDATE TRAIN_DETAILS SET Cost = @value WHERE Train_No = @trainNo";
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            cmd.Parameters.AddWithValue("@value", newValue);
            cmd.Parameters.AddWithValue("@trainNo", trainNo);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("**********************************");
                Console.WriteLine();
                Console.WriteLine("Train details are updated successfully!!");
                
                
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

        public static void SoftDeleteTrain()
        {
            using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;"))
            {
                con.Open();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Soft Delete Train");
                Console.WriteLine("-------------------------------");
                Console.Write("Enter train number to deactivate: ");
                int trainNo = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the class to deactivate: ");
                string classToDeactivate = ToCase(Console.ReadLine());

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        SqlCommand updateStatusCmd = new SqlCommand(@"
                    UPDATE TRAIN_DETAILS
                    SET Status = 'Inactive'
                    WHERE Train_No = @trainNo AND Class = @classToDeactivate;", con, transaction);

                        updateStatusCmd.Parameters.AddWithValue("@trainNo", trainNo);
                        updateStatusCmd.Parameters.AddWithValue("@classToDeactivate", classToDeactivate);

                        int rowsAffected = updateStatusCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            Console.WriteLine();
                            Console.WriteLine("*****************************************");
                            Console.WriteLine("Train status updated to 'Inactive'.");
                        }
                        else
                        {
                            transaction.Rollback();
                            Console.WriteLine("Train is not active.");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error during soft deletion: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    Console.ReadLine();
                }
            }
        }


        public static void ReactivateTrain()
        {
            using (SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;"))
            {
                con.Open();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Reactivate Train");
                Console.WriteLine("-------------------------------");
                Console.Write("Enter train number to reactivate: ");
                int trainNo = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the class to reactivate: ");
                string classToReactivate = ToCase(Console.ReadLine());

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        SqlCommand updateStatusCmd = new SqlCommand(@"
                    UPDATE TRAIN_DETAILS
                    SET Status = 'Active'
                    WHERE Train_No = @trainNo AND Class = @classToReactivate;", con, transaction);

                        updateStatusCmd.Parameters.AddWithValue("@trainNo", trainNo);
                        updateStatusCmd.Parameters.AddWithValue("@classToReactivate", classToReactivate);

                        int rowsAffected = updateStatusCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            Console.WriteLine();
                            Console.WriteLine("*****************************************");
                            Console.WriteLine("Train status updated to 'Active'.");
                        }
                        else
                        {
                            transaction.Rollback();
                            Console.WriteLine("No matching train/class found to update.");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error during reactivation: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    Console.ReadLine();
                }
            }
        }



        public static void ViewAllTrains()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand(@"
                                           SELECT 
                                           i.Train_No, 
                                           i.Train_Name, 
                                           i.Source, 
                                           i.Destination, 
                                           d.Class, 
                                           d.Availability, 
                                           d.Cost_per_seat,
                                           d.Status
                                           FROM TRAIN_INTRO i
                                           INNER JOIN TRAIN_DETAILS d ON i.Train_No = d.Train_No", con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15} {4,-10} {5,-12} {6,-10} {7,-10}",
                                  "Train No", "Train Name", "Source", "Destination", "Class", "Availability", "Cost", "Status");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15} {4,-10} {5,-12} {6,-10} {7,-10}",
                        reader["Train_No"],
                        reader["Train_Name"],
                        reader["Source"],
                        reader["Destination"],
                        reader["Class"],
                        reader["Availability"],
                        reader["Cost_per_seat"],
                        reader["Status"]);
                    
                }

                reader.Close();
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
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
        }
    }
}

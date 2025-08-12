using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System
{
    internal class TrainByNum
    {
        public static void GetTrainByNum()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");

            Console.Write("Enter Train Number: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand(@"
        SELECT 
            i.Train_No,
            i.Train_Name,
            i.Source,
            i.Destination,
            d.Class,
            d.Availability,
            d.Cost_per_seat
        FROM TRAIN_INTRO i
        INNER JOIN TRAIN_DETAILS d ON i.Train_No = d.Train_No
        WHERE i.Train_No = @trainNo", con);

            cmd.Parameters.AddWithValue("@trainNo", trainNo);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine("{0,-10} {1,-15} {2,-10} {3,-10} {4,-10} {5,-12} {6,-10}",
                                      "Train No", "Train Name", "Source", "Destination", "Class", "Availability_per_class", "Cost_per_seat");
                    Console.WriteLine("--------------------------------------------------------------");
                    
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,-10} {1,-15} {2,-10} {3,-10} {4,-10} {5,-12} {6,-10}",
                            reader["Train_No"],
                            reader["Train_Name"],
                            reader["Source"],
                            reader["Destination"],
                            reader["Class"],
                            reader["Availability"],
                            reader["Cost_per_seat"]);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No train found.");
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

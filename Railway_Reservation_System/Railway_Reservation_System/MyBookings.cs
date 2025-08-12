using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System
{
    internal class MyBookings
    {
        public static void ViewBookings(int custID)
        {
            string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM BOOKING_TABLE WHERE CustID = @CustID", con);
                cmd.Parameters.AddWithValue("@CustID", custID);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine();
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("================= Your Bookings ================");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("------------------------------------------------------------------------------------------");
                        Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-20} {4,-10} {5,-10} {6,-15} {7,-6} {8,-10} {9,-12} {10,-12}",
    "Train No", "PNR No", "Seat No", "Passenger Name", "Gender", "Class", "Journey Date", "Qty", "Cost", "Status", "Booked on");
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");


                        while (reader.Read())
                        {
                            string fullName = reader["FirstName"] + " " + reader["LastName"];
                            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-20} {4,-10} {5,-10} {6,-15} {7,-6} {8,-10} {9,-12} {10,-12}",
                                reader["Train_No"],
                                reader["PNR_No"],
                                reader["Seat_No"], 
                                fullName,
                                reader["Gender"],
                                reader["Class"],
                                Convert.ToDateTime(reader["Journey_Date"]).ToShortDateString(),
                                reader["Quantity"],
                                reader["Total_cost"],
                                reader["Journey_Status"],
                                Convert.ToDateTime(reader["Booking_date"]).ToShortDateString());
                        }

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have no bookings.");
                        Console.WriteLine();
                    }

                    reader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }
        }

        public static void ViewAllBookings()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM BOOKING_TABLE", con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("{0,-10} {1,-10} {2,-20} {3,-10} {4,-10} {5,-15} {6,-6} {7,-10} {8,-12} {9,-12}",
    "Train No", "PNR No", "Passenger Name", "Gender", "Class", "Journey Date", "Qty", "Cost", "Status", "Booked on");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------");

                while (reader.Read())
                {
                    string fullName = reader["FirstName"] + " " + reader["LastName"];
                    Console.WriteLine("{0,-10} {1,-10} {2,-20} {3,-10} {4,-10} {5,-15} {6,-6} {7,-10} {8,-12} {9,-12}",
                        reader["Train_No"],
                        reader["PNR_No"],
                        fullName,
                        reader["Gender"],
                        reader["Class"],
                        Convert.ToDateTime(reader["Journey_Date"]).ToShortDateString(),
                        reader["Quantity"],
                        reader["Total_cost"],
                        reader["Journey_Status"],
                        Convert.ToDateTime(reader["Booking_date"]).ToShortDateString());
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

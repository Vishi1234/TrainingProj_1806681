using System;
using System.Data.SqlClient;
using System.IO;

namespace Railway_Reservation_System
{
    public class ByPNR
    {
        public static void DownloadTicketByPNR(int pnr)
        {
            string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;";
            string folderPath = @"C:\Users\vidushij\TrainingProj_1806681\Railway_Reservation_System";
            string filePath = Path.Combine(folderPath, $"Ticket_{pnr}.txt");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM BOOKING_TABLE WHERE PNR_No = @PNR", con);
                cmd.Parameters.AddWithValue("@PNR", pnr);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No ticket found for the given PNR.");
                        return;
                    }

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("=====================================");
                        writer.WriteLine("           Train Ticket              ");
                        writer.WriteLine("=====================================");

                        while (reader.Read())
                        {
                            writer.WriteLine($"PNR Number     : {reader["PNR_No"]}");
                            writer.WriteLine($"Passenger Name : {reader["FirstName"]} {reader["LastName"]}");
                            writer.WriteLine($"Gender         : {reader["Gender"]}");
                            writer.WriteLine($"Train Number   : {reader["Train_No"]}");
                            writer.WriteLine($"Class          : {reader["Class"]}");
                            writer.WriteLine($"Seat Number    : {reader["Seat_No"]}");
                            writer.WriteLine($"Journey Date   : {Convert.ToDateTime(reader["Journey_Date"]).ToShortDateString()}");
                            writer.WriteLine($"Booking Date   : {Convert.ToDateTime(reader["Booking_date"]).ToShortDateString()}");
                            writer.WriteLine($"Journey Status : {reader["Journey_Status"]}");
                            writer.WriteLine($"Cost per Seat  : ₹{reader["Cost"]}");
                            writer.WriteLine($"Total Cost     : ₹{reader["Total_cost"]}");
                            writer.WriteLine("-------------------------------------");
                        }

                        writer.WriteLine("Thank you for booking with us!");
                        Console.WriteLine();
                    }

                    Console.WriteLine($"Ticket downloaded successfully: {filePath}");
                    Console.WriteLine();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }
        }
    }

    public class DownloadTicket
    {
        public static void Downloading()
        {
            Console.Write("Enter your PNR number: ");
            int pnr = Convert.ToInt32(Console.ReadLine());
            ByPNR.DownloadTicketByPNR(pnr);
        }
    }
}

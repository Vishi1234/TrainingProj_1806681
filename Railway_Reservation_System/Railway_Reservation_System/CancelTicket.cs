using System;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation_System
{
    public class CancelTicket
    {
        private static string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;";

        public static void CancelBookingByPNRAndSeat(string pnrInput, string seatInput)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CancelTrainBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!int.TryParse(pnrInput, out int pnr) || !int.TryParse(seatInput, out int seatNo))
                {
                    Console.WriteLine("Invalid input. PNR and Seat No must be numeric.");
                    Console.WriteLine();
                    return;
                }

                cmd.Parameters.AddWithValue("@PNR", pnr);
                cmd.Parameters.AddWithValue("@SeatNo", seatNo);

                SqlParameter statusParam = new SqlParameter("@Status", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter refundParam = new SqlParameter("@RefundAmount", SqlDbType.Float)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(statusParam);
                cmd.Parameters.Add(refundParam);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    string status = statusParam.Value != DBNull.Value ? statusParam.Value.ToString() : "Unknown";
                    double refund = refundParam.Value != DBNull.Value ? Convert.ToDouble(refundParam.Value) : 0;

                    Console.WriteLine();
                    Console.WriteLine("=====================================");
                    Console.WriteLine("         Cancellation Summary        ");
                    Console.WriteLine("=====================================");
                    Console.WriteLine($"PNR Number        : {pnr}");
                    Console.WriteLine($"Seat Number       : {seatNo}");
                    Console.WriteLine($"Status            : {status}");

                    if (status.ToLower().Contains("successful"))
                    {
                        Console.WriteLine($"Refund Amount     : {refund:F2}");
                    }

                    Console.WriteLine("=====================================");
                    Console.WriteLine();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }
        }


        public static void StartCancellationProcess()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("========= Ticket Cancellation ==========");
            Console.WriteLine("----------------------------------------");

            Console.Write("Enter PNR number to cancel: ");
            string pnrToCancel = Console.ReadLine()?.Trim();

            Console.Write("Enter Seat number to cancel: ");
            string seatToCancel = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(pnrToCancel) && !string.IsNullOrEmpty(seatToCancel))
            {
                CancelBookingByPNRAndSeat(pnrToCancel, seatToCancel);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter both PNR and Seat number.");
            }
        }
    }
}




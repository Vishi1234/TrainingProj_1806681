using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation_System
{
    public class Bookings
    {
        public static string ToCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(input.ToLower());
        }

        public static void BookTrainByname(string email)
        {
            string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;";

            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("========= Train Ticket Booking =========");
            Console.WriteLine("----------------------------------------");

            Console.Write("Enter Train Name: ");
            string trainName = ToCase(Console.ReadLine());

            Console.Write("Enter Class (e.g., sleeper, AC): ");
            string trainClass = ToCase(Console.ReadLine());

            DateTime journeyDate;
            while (true)
            {
                Console.Write("Enter the journey date (yyyy-MM-dd): ");
                string inputDate = Console.ReadLine();

                if (!DateTime.TryParse(inputDate, out journeyDate))
                {
                    Console.WriteLine("Invalid format. Please use yyyy-MM-dd.");
                    continue;
                }

                if (journeyDate.Date < DateTime.Today)
                {
                    Console.WriteLine("Invalid date. Journey date cannot be before today.");
                    continue;
                }

                break; 
            }

            int quantity;
            while (true)
            {
                Console.Write("Enter Quantity (number of passengers): ");
                string inputQty = Console.ReadLine();

                if (!int.TryParse(inputQty, out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity. Please enter a positive number.");
                    continue;
                }

                break; 
            }


            List<Tuple<string, string, string>> passengers = new List<Tuple<string, string, string>>();

            for (int i = 0; i < quantity; i++)
            {
                Console.WriteLine($"Enter details for Passenger {i + 1}:");

                Console.Write("First Name: ");
                string firstName = ToCase(Console.ReadLine());

                Console.Write("Last Name: ");
                string lastName = ToCase(Console.ReadLine());

                Console.Write("Gender: ");
                string gender = ToCase(Console.ReadLine());

                passengers.Add(new Tuple<string, string, string>(firstName, lastName, gender));
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    foreach (var passenger in passengers)
                    {
                        using (SqlCommand cmd = new SqlCommand("BookTrainTicket", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@TrainName", trainName);
                            cmd.Parameters.AddWithValue("@Class", trainClass);
                            cmd.Parameters.AddWithValue("@Quantity", 1); 
                            cmd.Parameters.AddWithValue("@FirstName", passenger.Item1);
                            cmd.Parameters.AddWithValue("@LastName", passenger.Item2);
                            cmd.Parameters.AddWithValue("@Gender", passenger.Item3);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@JourneyDate", journeyDate.ToString("yyyy-MM-dd"));

                            SqlParameter totalCostParam = new SqlParameter("@TotalCost", SqlDbType.Int);
                            totalCostParam.Direction = ParameterDirection.Output;

                            SqlParameter statusParam = new SqlParameter("@Status", SqlDbType.NVarChar, 100);
                            statusParam.Direction = ParameterDirection.Output;

                            SqlParameter pnrParam = new SqlParameter("@PNR_No", SqlDbType.Int);
                            pnrParam.Direction = ParameterDirection.Output;

                            SqlParameter jrnyStatusParam = new SqlParameter("@JourneyStatusOutput", SqlDbType.NVarChar, 15);
                            jrnyStatusParam.Direction = ParameterDirection.Output;

                            cmd.Parameters.Add(totalCostParam);
                            cmd.Parameters.Add(statusParam);
                            cmd.Parameters.Add(pnrParam);
                            cmd.Parameters.Add(jrnyStatusParam);

                            cmd.ExecuteNonQuery();

                            Console.WriteLine();
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("============== Booking Summary ==============");
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine($"Passenger Name : {passenger.Item1} {passenger.Item2}");
                            Console.WriteLine($"Gender         : {passenger.Item3}");
                            Console.WriteLine($"Train Name     : {trainName}");
                            Console.WriteLine($"Class Selected : {trainClass}");
                            Console.WriteLine($"PNR Number     : {pnrParam.Value}");
                            Console.WriteLine($"Total Cost     : {totalCostParam.Value}");
                            Console.WriteLine($"Status         : {statusParam.Value}");
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine("Do you want to download this ticket? Enter y if yes , N if No");
                            char ans = Convert.ToChar(Console.ReadLine());
                            if (ans == 'Y' || ans == 'y')
                            {
                                DownloadTicket.Downloading();
                              
                            }
                            Console.WriteLine();
                            break;
                            
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }
        }
    }
}

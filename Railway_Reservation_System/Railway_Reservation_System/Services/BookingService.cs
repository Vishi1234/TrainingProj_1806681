using System;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation_System
{
    public class BookingService
    {
        private readonly string _connectionString;

        public BookingService(string connectionString) =>
            _connectionString = connectionString;

        public BookingResult BookPassenger(string trainName, string trainClass, DateTime journeyDate,
                                    string email, string firstName, string lastName, string gender)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("BookTrainTicket", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@TrainName", trainName);
            command.Parameters.AddWithValue("@Class", trainClass);
            command.Parameters.AddWithValue("@Quantity", 1); 
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@JourneyDate", journeyDate.ToString("yyyy-MM-dd"));

            // Output parameters
            var totalCostParam = new SqlParameter("@TotalCost", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var statusParam = new SqlParameter("@Status", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
            var pnrParam = new SqlParameter("@PNR_No", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var journeyStatusParam = new SqlParameter("@JourneyStatusOutput", SqlDbType.NVarChar, 15) { Direction = ParameterDirection.Output };

            command.Parameters.Add(totalCostParam);
            command.Parameters.Add(statusParam);
            command.Parameters.Add(pnrParam);
            command.Parameters.Add(journeyStatusParam);

            connection.Open();
            command.ExecuteNonQuery();

            return new BookingResult
            {
                PassengerName = $"{firstName} {lastName}",
                Gender = gender,
                TrainName = trainName,
                Class = trainClass,
                PNR = pnrParam.Value is int pnr ? pnr : 0,
                TotalCost = totalCostParam.Value is int cost ? cost : 0,
                Status = statusParam.Value?.ToString()
            };
        }


        public class BookingResult
        {
            public string PassengerName { get; set; }
            public string Gender { get; set; }
            public string TrainName { get; set; }
            public string Class { get; set; }
            public int PNR { get; set; }
            public decimal TotalCost { get; set; }
            public string Status { get; set; }
        }
    }
}

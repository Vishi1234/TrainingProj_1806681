using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Railway_Reservation_System
{
    public class MyBookingService
    {
        private readonly string _connectionString;

        public MyBookingService(string connectionString) =>
            _connectionString = connectionString;

        public List<BookingRecord> GetBookingsByCustomer(int customerId)
        {
            var bookings = new List<BookingRecord>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT * FROM BOOKING_TABLE WHERE CustID = @CustID", connection);
            command.Parameters.AddWithValue("@CustID", customerId);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                bookings.Add(MapBooking(reader));
            }

            return bookings;
        }

        public List<BookingRecord> GetAllBookings()
        {
            var bookings = new List<BookingRecord>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT * FROM BOOKING_TABLE", connection);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                bookings.Add(MapBooking(reader));
            }

            return bookings;
        }

        private BookingRecord MapBooking(SqlDataReader reader)
        {
            return new BookingRecord
            {
                TrainNo = reader["Train_No"]?.ToString(),
                PNR = Convert.ToInt32(reader["PNR_No"]),
                SeatNo = reader["Seat_No"] is DBNull ? 0 : Convert.ToInt32(reader["Seat_No"]),
                PassengerName = $"{reader["FirstName"]} {reader["LastName"]}",
                Gender = reader["Gender"]?.ToString(),
                Class = reader["Class"]?.ToString(),
                JourneyDate = Convert.ToDateTime(reader["Journey_Date"]),
                Quantity = Convert.ToInt32(reader["Quantity"]),
                TotalCost = Convert.ToDecimal(reader["Total_cost"]),
                JourneyStatus = reader["Journey_Status"]?.ToString(),
                BookingDate = Convert.ToDateTime(reader["Booking_date"])
            };
        }

        public class BookingRecord
        {
            public string TrainNo { get; set; }
            public int PNR { get; set; }
            public int SeatNo { get; set; }
            public string PassengerName { get; set; }
            public string Gender { get; set; }
            public string Class { get; set; }
            public DateTime JourneyDate { get; set; }
            public int Quantity { get; set; }
            public decimal TotalCost { get; set; }
            public string JourneyStatus { get; set; }
            public DateTime BookingDate { get; set; }
        }
    }
}

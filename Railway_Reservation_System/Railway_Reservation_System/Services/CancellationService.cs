using System;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation_System
{
    public class CancellationService
    {
        private readonly string _connectionString;

        public CancellationService(string connectionString) =>
            _connectionString = connectionString;

        public CancellationResult CancelBooking(int pnr, int seatNo)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("CancelTrainBooking", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@PNR", pnr);
            command.Parameters.AddWithValue("@SeatNo", seatNo);

            var statusParam = new SqlParameter("@Status", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Output
            };

            var refundParam = new SqlParameter("@RefundAmount", SqlDbType.Float)
            {
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(statusParam);
            command.Parameters.Add(refundParam);

            connection.Open();
            command.ExecuteNonQuery();

            return new CancellationResult
            {
                PNR = pnr,
                SeatNo = seatNo,
                Status = statusParam.Value?.ToString() ?? "Unknown",
                RefundAmount = refundParam.Value != DBNull.Value ? Convert.ToDouble(refundParam.Value) : 0
            };
        }

        public class CancellationResult
        {
            public int PNR { get; set; }
            public int SeatNo { get; set; }
            public string Status { get; set; }
            public double RefundAmount { get; set; }
        }
    }
}

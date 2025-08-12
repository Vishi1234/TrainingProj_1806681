using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Railway_Reservation_System
{
    public class RegistrationService
    {
        private readonly string _connectionString;

        public RegistrationService(string connectionString) =>
            _connectionString = connectionString;

        public RegistrationResult RegisterUser(string firstName, string lastName, string gender, string phone, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return new RegistrationResult { Status = "Missing required fields." };
            }

            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                return new RegistrationResult { Status = "Invalid phone number." };
            }

            if (!email.Contains("@"))
            {
                return new RegistrationResult { Status = "Invalid email address." };
            }

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("RegisterCustomer", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@fname", ToCase(firstName));
            command.Parameters.AddWithValue("@lname", ToCase(lastName));
            command.Parameters.AddWithValue("@gender", ToCase(gender));
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@pass", password);

            var outputId = new SqlParameter("@generatedid", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputId);

            connection.Open();
            command.ExecuteNonQuery();

            return new RegistrationResult
            {
                CustomerId = outputId.Value is int id ? id : 0,
                FirstName = ToCase(firstName),
                LastName = ToCase(lastName),
                Gender = ToCase(gender),
                Phone = phone,
                Email = email,
                Status = "Registration successful."
            };
        }

        private static string ToCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;
            var cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(input.ToLower());
        }

        public class RegistrationResult
        {
            public int CustomerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }
        }
    }
}


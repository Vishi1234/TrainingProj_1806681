using NUnit.Framework;
using Railway_Reservation_System;

namespace RailwayReservationTests
{
    [TestFixture]
    public class RegistrationServiceTests
    {
        private RegistrationService _registrationService;

        [SetUp]
        public void Setup()
        {
            string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;";
            _registrationService = new RegistrationService(connectionString);
        }

        [Test]
        public void RegisterUser_WithValidInput_ShouldReturnSuccessStatus()
        {
            // Arrange
            string firstName = "Parth";
            string lastName = "Singh";
            string gender = "Male";
            string phone = "9876543210";
            string email = "parth@example.com";
            string password = "secure123";

            // Act
            var result = _registrationService.RegisterUser(firstName, lastName, gender, phone, email, password);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.EqualTo("Registration successful."));
            Assert.That(result.CustomerId, Is.GreaterThan(0));
            Assert.That(result.Email, Is.EqualTo(email));
        }

        [Test]
        public void RegisterUser_WithInvalidPhone_ShouldReturnErrorStatus()
        {
            var result = _registrationService.RegisterUser("Parth", "Singh", "Male", "123", "parth@example.com", "pass");
            Assert.That(result.Status, Is.EqualTo("Invalid phone number."));
        }

        [Test]
        public void RegisterUser_WithInvalidEmail_ShouldReturnErrorStatus()
        {
            var result = _registrationService.RegisterUser("Parth", "Singh", "Male", "9876543210", "parth.example.com", "pass");
            Assert.That(result.Status, Is.EqualTo("Invalid email address."));
        }

        [Test]
        public void RegisterUser_WithMissingFields_ShouldReturnErrorStatus()
        {
            var result = _registrationService.RegisterUser("", "", "", "", "", "");
            Assert.That(result.Status, Is.EqualTo("Missing required fields."));
        }
    }
}


using NUnit.Framework;
using Railway_Reservation_System;
using System;

namespace RailwayReservationTests
{
    [TestFixture]
    [TestFixture]
    public class BookingServiceTests
    {
        private BookingService _bookingService;

        [SetUp]
        public void Setup()
        {
            string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;";
            _bookingService = new BookingService(connectionString);
        }

        [Test]
        public void BookPassenger_WithValidInput_ShouldReturnSuccessStatus()
        {
            // Arrange
            string trainName = "Rajdhani Express";
            string trainClass = "2AC";
            DateTime journeyDate = DateTime.Today.AddDays(2);
            string email = "parth@gmail.com";
            string firstName = "Parth";
            string lastName = "Singh";
            string gender = "Male";

            // Act
            var result = _bookingService.BookPassenger(trainName, trainClass, journeyDate, email, firstName, lastName, gender);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.EqualTo("Booking successful."));
            Assert.That(result.PNR, Is.GreaterThan(0));
            Assert.That(result.TotalCost, Is.GreaterThan(0));
            Assert.That(result.PassengerName, Is.EqualTo($"{firstName} {lastName}"));
        }

        [Test]
        public void BookPassenger_WithInvalidClass_ShouldReturnFailureStatus()
        {
            // Arrange
            string trainName = "Rajdhani Express";
            string trainClass = "Luxury"; // Assuming this class doesn't exist
            DateTime journeyDate = DateTime.Today.AddDays(2);
            string email = "parth@gmail.com";
            string firstName = "Parth";
            string lastName = "Singh";
            string gender = "Male";

            // Act
            var result = _bookingService.BookPassenger(trainName, trainClass, journeyDate, email, firstName, lastName, gender);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.EqualTo("No matching train/class found."));
            Assert.That(result.PNR, Is.EqualTo(0));
            Assert.That(result.TotalCost, Is.EqualTo(0));
        }
    }


}

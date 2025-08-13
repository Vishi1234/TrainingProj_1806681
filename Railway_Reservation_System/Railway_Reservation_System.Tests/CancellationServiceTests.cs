using NUnit.Framework;
using Railway_Reservation_System;
using System;

namespace RailwayReservationTests
{
    [TestFixture]
    public class CancellationServiceTests
    {
        private CancellationService _cancellationService;

        [SetUp]
        public void Setup()
        {
            string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;";
            _cancellationService = new CancellationService(connectionString);
        }

        [Test]
        public void CancelBooking_WithValidPNRAndSeat_ShouldReturnSuccessStatus()
        {
            // Arrange
            int validPNR = 23483 ; // Replace with a real PNR from your DB
            int validSeatNo =6;

            // Act
            var result = _cancellationService.CancelBooking(validPNR, validSeatNo);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.EqualTo("Cancellation successful."));
            Assert.That(result.RefundAmount, Is.GreaterThan(0));
        }

        [Test]
        public void CancelBooking_WithInvalidPNR_ShouldReturnFailureStatus()
        {
            // Arrange
            int invalidPNR = 999999;
            int seatNo = 1;

            // Act
            var result = _cancellationService.CancelBooking(invalidPNR, seatNo);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.EqualTo("PNR and Seat not found."));
            Assert.That(result.RefundAmount, Is.EqualTo(0));
        }
    }
}


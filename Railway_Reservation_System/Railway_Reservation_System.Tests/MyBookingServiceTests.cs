using NUnit.Framework;
using Railway_Reservation_System;
using System.Collections.Generic;

namespace RailwayReservationTests
{
    [TestFixture]
    public class MyBookingServiceTests
    {
        private MyBookingService _bookingQueryService;

        [SetUp]
        public void Setup()
        {
            string connectionString = "Data Source=ICS-LT-3NQ0LQ3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;";
            _bookingQueryService = new MyBookingService(connectionString);
        }

        [Test]
        public void GetBookingsByCustomer_WithValidCustomerId_ShouldReturnBookings()
        {
            int customerId = 1; // Replace with a valid ID from your DB

            List<MyBookingService.BookingRecord> bookings = _bookingQueryService.GetBookingsByCustomer(customerId);

            Assert.That(bookings, Is.Not.Null);
            Assert.That(bookings.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetBookingsByCustomer_WithInvalidCustomerId_ShouldReturnEmptyList()
        {
            int customerId = 99999;

            List<MyBookingService.BookingRecord> bookings = _bookingQueryService.GetBookingsByCustomer(customerId);

            Assert.That(bookings, Is.Not.Null);
            Assert.That(bookings.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetAllBookings_ShouldReturnAllRecords()
        {
            List<MyBookingService.BookingRecord> bookings = _bookingQueryService.GetAllBookings();

            Assert.That(bookings, Is.Not.Null);
            Assert.That(bookings.Count, Is.GreaterThan(0));
        }
    }
}


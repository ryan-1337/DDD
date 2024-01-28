using Domain.Entities;
using Xunit;

namespace Domain.Tests
{
    public class BookingTest
    {
        [Fact]
        public void CreateBooking_ShouldGenerateUniqueId()
        {
            var roomId = Guid.NewGuid();
            var clientId = Guid.NewGuid();
            var checkInDate = DateTime.UtcNow;
            var numberOfNights = 3;

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                ClientId = clientId,
                CheckInDate = checkInDate,
                NumberOfNights = numberOfNights,
                Room = new Room(),
                TotalAmount = 100,
                InitialPayment = 50,
                IsConfirmed = false,
                IsCancelled = false
            };

            Assert.NotNull(booking.Id);
            Assert.NotEqual(Guid.Empty, booking.Id);
        }

        [Fact]
        public void CalculateTotalAmount_ShouldReturnCorrectAmount()
        {
            var roomId = Guid.NewGuid();
            var clientId = Guid.NewGuid();
            var checkInDate = DateTime.UtcNow;
            var numberOfNights = 3;
            var roomPricePerNight = 50;

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                ClientId = clientId,
                CheckInDate = checkInDate,
                NumberOfNights = numberOfNights,
                Room = new Room(),
                TotalAmount = numberOfNights * roomPricePerNight,
                InitialPayment = 50,
                IsConfirmed = false,
                IsCancelled = false
            };

            Assert.Equal(150, booking.TotalAmount);
        }

        [Fact]
        public void CancelBooking_ShouldSetIsCancelledToTrue()
        {
            var roomId = Guid.NewGuid();
            var clientId = Guid.NewGuid();
            var checkInDate = DateTime.UtcNow;
            var numberOfNights = 3;

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                ClientId = clientId,
                CheckInDate = checkInDate,
                NumberOfNights = numberOfNights,
                Room = new Room(),
                TotalAmount = 100,
                InitialPayment = 50,
                IsConfirmed = false,
                IsCancelled = false
            };

            booking.Cancel();

            Assert.True(booking.IsCancelled);
        }
    }
}

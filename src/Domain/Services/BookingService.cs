using Domain.Entities;

namespace Domain.Services;

public class BookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly WalletService _walletService;

    public BookingService(IBookingRepository bookingRepository, WalletService walletService)
    {
        _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        _walletService = walletService ?? throw new ArgumentNullException(nameof(walletService));
    }

    public async Task MakeReservation(Guid clientId, DateTime checkInDate, int numberOfNights, Room selectedRoom, string currency)
    {
        decimal totalAmount = selectedRoom.PricePerNight * numberOfNights;
        await _walletService.DebitWallet(clientId, totalAmount * 0.5m, currency); // Débit de 50%

        var booking = new Booking
        {
            ClientId = clientId,
            CheckInDate = checkInDate,
            NumberOfNights = numberOfNights,
            Room = selectedRoom,
            TotalAmount = totalAmount,
            InitialPayment = totalAmount * 0.5m,
            IsConfirmed = false,
            IsCancelled = false
        };

        await _bookingRepository.AddAsync(booking);
    }

    public async Task ConfirmReservation(Guid bookingId, string currency)
    {
        // Vérifier si la réservation existe
        var booking = await _bookingRepository.GetByIdAsync(bookingId);
        if (booking == null)
        {
            //throw new ReservationNotFoundException();
            return;
        }

        decimal remainingAmount = booking.TotalAmount - booking.InitialPayment;
        await _walletService.DebitWallet(booking.ClientId, remainingAmount, currency);

        booking.IsConfirmed = true;

        await _bookingRepository.UpdateAsync(booking);
    }

    public async Task CancelReservation(Guid bookingId)
    {
        var booking = await _bookingRepository.GetByIdAsync(bookingId);
        if (booking == null)
        {
            //throw new ReservationNotFoundException();
            return;
        }

        booking.IsCancelled = true;

        await _bookingRepository.UpdateAsync(booking);
    }
}
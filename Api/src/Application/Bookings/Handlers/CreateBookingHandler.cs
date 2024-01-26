using Application.Bookings.Queries;
using Application.Bookings.Responses;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Handlers;

public class CreateBookingHandler : IRequestHandler<CreateBookingQuery, BookingResponse>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IWalletService _walletService;

    public CreateBookingHandler(IBookingRepository bookingRepository, IRoomRepository roomRepository,
        IWalletService walletService)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
        _walletService = walletService;
    }

    public async Task<BookingResponse> Handle(CreateBookingQuery query, CancellationToken cancellationToken)
    {
        var selectedRoom = await _roomRepository.GetByIdAsync(query.Room);

        decimal totalAmount = selectedRoom.PricePerNight * query.NumberOfNights;
        await _walletService.DebitWallet(Guid.Parse(query.ClientId), totalAmount * 0.5m, "EUR"); // Débit de 50%

        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            ClientId = Guid.Parse(query.ClientId),
            CheckInDate = query.CheckInDate,
            NumberOfNights = query.NumberOfNights,
            Room = selectedRoom,
            TotalAmount = totalAmount,
            InitialPayment = totalAmount * 0.5m,
            IsConfirmed = query.IsConfirmed.HasValue,
            IsCancelled = query.IsCancelled.HasValue
        };

        await _bookingRepository.AddAsync(booking);
        return new BookingResponse
        {
            Id = booking.Id.ToString(), ClientId = booking.ClientId.ToString(), NumberOfNights = booking.NumberOfNights,
            Room = booking.Room.Id, InitialPayment = booking.InitialPayment, CheckInDate = booking.CheckInDate,
            TotalAmount = booking.TotalAmount
        };
    }
}
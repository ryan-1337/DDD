using Application.Abstractions.Messaging;
using Application.Bookings.Queries;
using Application.Bookings.Responses;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Bookings.Handlers;

public class CreateBookingHandler : IRequestHandler<CreateBookingQuery, IResult<BookingResponse>>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IWalletService _walletService;
    private readonly IClientRepository _clientRepository;

    public CreateBookingHandler(IBookingRepository bookingRepository, IRoomRepository roomRepository,
        IWalletService walletService, IClientRepository clientRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
        _walletService = walletService;
        _clientRepository = clientRepository;
    }

    public async Task<IResult<BookingResponse>> Handle(CreateBookingQuery query, CancellationToken cancellationToken)
    {
        var selectedRoom = await _roomRepository.GetByIdAsync(query.Room);
        var client = await _clientRepository.GetClientById(query.ClientId);

        if (client == null)
        {
            return Result<BookingResponse>.Failure("Client not found", StatusCodes.Status404NotFound);
        } 

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
            IsConfirmed = false,
            IsCancelled = false
        };

        await _bookingRepository.AddAsync(booking);
        var response = new BookingResponse
        {
            Id = booking.Id.ToString(), ClientId = booking.ClientId.ToString(), NumberOfNights = booking.NumberOfNights,
            Room = booking.Room.Id, InitialPayment = booking.InitialPayment, CheckInDate = booking.CheckInDate,
            TotalAmount = booking.TotalAmount
        };

        return Result<BookingResponse>.Success(response);
    }
}
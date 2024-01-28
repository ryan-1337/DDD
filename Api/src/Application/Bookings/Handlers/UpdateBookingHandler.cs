using Application.Bookings.Queries;
using Application.Bookings.Responses;
using Domain;
using MediatR;

namespace Application.Bookings.Handlers;

public class UpdateBookingHandler : IRequestHandler<UpdateBookingQuery, BookingResponse>
{
    private readonly IBookingRepository _bookingRepository;

    public UpdateBookingHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }


    public async Task<BookingResponse> Handle(UpdateBookingQuery query, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(Guid.Parse(query.BookingId));
        booking.IsConfirmed = query.Status == "confirmed";
        booking.IsCancelled = !booking.IsConfirmed;

        _bookingRepository.UpdateAsync(booking);
        return new BookingResponse
        {
            Id = booking.Id.ToString(), ClientId = booking.ClientId.ToString(), IsCancelled = booking.IsCancelled,
            IsConfirmed = booking.IsConfirmed
        };
    }
}
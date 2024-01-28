using Application.Abstractions.Messaging;
using Application.Bookings.Responses;

namespace Application.Bookings.Queries;

public class UpdateBookingQuery : IQuery<BookingResponse>
{
    public required string BookingId { get; init; }
    
    public required string Status { get; init; }
}
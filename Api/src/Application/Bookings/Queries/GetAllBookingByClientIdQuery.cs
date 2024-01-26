using Application.Abstractions.Messaging;
using Application.Bookings.Responses;

namespace Application.Bookings.Queries;
public class GetAllBookingByClientIdQuery : IQuery<List<BookingResponse>>
{
    public required string ClientId { get; init; }
}
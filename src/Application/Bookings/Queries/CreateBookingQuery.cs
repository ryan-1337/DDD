using Application.Abstractions.Messaging;
using Application.Bookings.Responses;

namespace Application.Bookings.Queries;

public class CreateBookingQuery : IQuery<BookingResponse>
{
    public required string ClientId { get; init; }
    public required DateTime CheckInDate { get; set; }
    public required int NumberOfNights { get; set; }
    public required string Room { get; set; }
    public required decimal TotalAmount { get; set; }
    public required decimal InitialPayment { get; set; }
    public bool? IsConfirmed { get; set; }
    public bool? IsCancelled { get; set; }
}
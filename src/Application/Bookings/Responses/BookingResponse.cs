namespace Application.Bookings.Responses;

public class BookingResponse
{
    public string Id { get; set; }
    public string ClientId { get; init; }
    public DateTime CheckInDate { get; set; }
    public int NumberOfNights { get; set; }
    public string Room { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal InitialPayment { get; set; }
    public bool IsConfirmed { get; set; }
    public bool IsCancelled { get; set; }
}
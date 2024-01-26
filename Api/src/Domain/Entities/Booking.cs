namespace Domain.Entities;

public class Booking
{
    public Guid Id { get; set; }
    public Guid ClientId { get; init; }
    public DateTime CheckInDate { get; set; }
    public int NumberOfNights { get; set; }
    public Room Room { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal InitialPayment { get; set; }
    public bool IsConfirmed { get; set; }
    public bool IsCancelled { get; set; }

    public Booking()
    {
        
    }

    public Booking(Guid clientId, DateTime checkInDate, int numberOfNights, Room room, decimal totalAmount,
        decimal initialPayment)
    {
        Id = Guid.NewGuid();
        ClientId = clientId;
        CheckInDate = checkInDate;
        NumberOfNights = numberOfNights;
        Room = room;
        TotalAmount = totalAmount;
        InitialPayment = initialPayment;
    }

    public void Confirm()
    {
        IsConfirmed = true;
    }

    public void Cancel()
    {
        IsCancelled = true;
    }
}
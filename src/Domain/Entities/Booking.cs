namespace Domain.Entities;

public class Booking
{
    public Guid Id { get; }
    public Guid ClientId { get; init; }
    public DateTime CheckInDate { get; }
    public int NumberOfNights { get; }
    public Room Room { get; }
    public decimal TotalAmount { get; }
    public decimal InitialPayment { get; }
    public bool IsConfirmed { get; private set; }
    public bool IsCancelled { get; private set; }

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
namespace Domain.Entities;

public class Payment
{
    public Guid Id { get; }
    public Client Client { get; }
    public decimal Amount { get; }
    public DateTime Timestamp { get; }

    public Payment(Client client, decimal amount, DateTime timestamp)
    {
        Id = Guid.NewGuid();
        Client = client;
        Amount = amount;
        Timestamp = timestamp;
    }
}
namespace Domain.Entities;

public class Payment
{
    public Guid Id { get; set; }
    public Client Client { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }

    public Payment()
    {
        
    }
    
    public Payment(Client client, decimal amount, DateTime timestamp)
    {
        Id = Guid.NewGuid();
        Client = client;
        Amount = amount;
        Timestamp = timestamp;
    }
}
using Domain.ValueObjects;

namespace Domain.Entities;

public class Wallet
{
    public Guid Id { get; set; }
    public Guid ClientId{ get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public Wallet()
    {
        
    }
    
    public Wallet(Guid clientId, decimal amount, string currency)
    {
        Id = Guid.NewGuid();
        ClientId = clientId;
        Amount = amount;
        Currency = currency;
    }
    public Wallet(Guid clientId)
    {
        ClientId = ClientId;
    }
}
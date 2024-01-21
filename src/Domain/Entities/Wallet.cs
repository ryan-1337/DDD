using Domain.ValueObjects;

namespace Domain.Entities;

public class Wallet
{
    public Guid Id { get; }
    public Guid UserId{ get; }
    public decimal Amount { get; }
    
    public Currency Currency { get; }

    public Wallet(Guid id, Guid userId, decimal amount, Currency currency)
    {
        Id = id;
        UserId = userId;
        Amount = amount;
        Currency = currency;
    }
    public Wallet(Guid userId)
    {
        UserId = userId;
    }
}
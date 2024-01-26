using Domain.Entities;

namespace Domain;

public interface IWalletRepository
{
    Task<Wallet> GetByClientIdAsync(Guid clientId);
    Task AddAsync(Wallet wallet);
    Task UpdateAsync(Wallet wallet);
}
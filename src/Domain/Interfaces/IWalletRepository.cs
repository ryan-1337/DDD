using Domain.Entities;

namespace Domain;

public interface IWalletRepository
{
    Task<Wallet> GetByIdAsync(Guid clientId);
    Task AddAsync(Wallet wallet);
    Task UpdateAsync(Wallet wallet);
}
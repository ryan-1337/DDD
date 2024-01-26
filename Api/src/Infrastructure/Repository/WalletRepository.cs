using Domain;
using Domain.Entities;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class WalletRepository : IWalletRepository
{
    private readonly XyzHotelContext _dbContext;

    public WalletRepository(XyzHotelContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Wallet> GetByClientIdAsync(Guid clientId)
    {
        var walletDataAccess = await _dbContext.Wallets
            .SingleOrDefaultAsync(w => w.CLIENT_ID == clientId.ToString());

        return WalletMapper.MapToEntity(walletDataAccess);
    }
    
    public async Task AddAsync(Wallet wallet)
    {
        var walletDataAccess = WalletMapper.MapToDataAccess(wallet);
        await _dbContext.Wallets.AddAsync(walletDataAccess);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Wallet wallet)
    {
        var existingWallet = await _dbContext.Wallets
            .SingleOrDefaultAsync(w => w.CLIENT_ID == wallet.ClientId.ToString());

        if (existingWallet != null)
        {
            existingWallet.AMOUNT = wallet.Amount;
            existingWallet.CURRENCY = wallet.Currency;

            _dbContext.Wallets.Update(existingWallet);
            await _dbContext.SaveChangesAsync();
        }
    }
}

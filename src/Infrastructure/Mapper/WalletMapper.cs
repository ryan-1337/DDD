using Infrastructure.DataAccess.XyzHotel;

namespace Infrastructure.Mapper;

public static class WalletMapper
{
    public static Wallet MapToDataAccess(Domain.Entities.Wallet wallet)
    {
        if (wallet == null)
            return null;
        
        return new Wallet
        {
            ID = Guid.NewGuid().ToString(),
            CLIENT_ID = wallet.ClientId.ToString(),
            AMOUNT = wallet.Amount,
            CURRENCY = wallet.Currency
        };
    }
    
    public static Domain.Entities.Wallet MapToEntity(Wallet walletDataAccess)
    {
        if (walletDataAccess == null)
            return null;

        return new Domain.Entities.Wallet()
        {
            Id =  Guid.Parse(walletDataAccess.ID),
            ClientId = Guid.Parse(walletDataAccess.CLIENT_ID),
            Amount = walletDataAccess.AMOUNT,
            Currency = walletDataAccess.CURRENCY
        };
    }
}

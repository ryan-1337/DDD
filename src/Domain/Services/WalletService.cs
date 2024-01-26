using Domain.Entities;

namespace Domain.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;
    private readonly ICurrencyConversionService _currencyConversionService;

    public WalletService(IWalletRepository walletRepository, ICurrencyConversionService currencyConversionService)
    {
        _walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
        _currencyConversionService = currencyConversionService ?? throw new ArgumentNullException(nameof(currencyConversionService));
    }

    public async Task<bool> CreditWallet(Guid clientId, decimal amount, string currency)
    {
        var wallet = await _walletRepository.GetByClientIdAsync(clientId);

        if (wallet == null)
        {
            wallet = new Wallet(clientId, 0.0m, currency)
            {
                ClientId = clientId,
                Amount = 0.0m,
                Currency = currency
            };
        }

        decimal amountInEuros = _currencyConversionService.ConvertAmount(amount, currency, "EUR");

        wallet.Amount += amountInEuros;

        await _walletRepository.UpdateAsync(wallet);

        return true;
    }

    public async Task<bool> DebitWallet(Guid clientId, decimal amount, string currency)
    {
        var wallet = await _walletRepository.GetByClientIdAsync(clientId);

        if (wallet == null || wallet.Amount < amount)
        {
            return false; 
        }

        decimal amountInEuros = _currencyConversionService.ConvertAmount(amount, currency, "EUR");

        wallet.Amount -= amountInEuros;

        await _walletRepository.UpdateAsync(wallet);

        return true;
    }
}
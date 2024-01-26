namespace Domain;

public interface IWalletService
{
    Task<bool> DebitWallet(Guid clientId, decimal amount, string currency);
    Task<bool> CreditWallet(Guid clientId, decimal amount, string currency);
}
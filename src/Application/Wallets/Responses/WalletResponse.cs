namespace Application.Wallets.Responses;

public class WalletResponse
{
    public string Id { get; set; }
    public string ClientId{ get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}
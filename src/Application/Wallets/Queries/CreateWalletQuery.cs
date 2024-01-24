using Application.Abstractions.Messaging;
using Application.Wallets.Responses;

namespace Application.Wallets.Queries;

public class CreateWalletQuery : IQuery<WalletResponse>
{
    public string ClientId{ get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}
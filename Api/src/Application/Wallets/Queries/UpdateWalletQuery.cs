using Application.Abstractions.Messaging;
using Application.Wallets.Responses;

namespace Application.Wallets.Queries;

public class UpdateWalletQuery : IQuery<WalletResponse>
{
    public required string ClientId{ get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}
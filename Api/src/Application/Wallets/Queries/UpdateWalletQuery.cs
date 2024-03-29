using Application.Abstractions.Messaging;
using Application.Wallets.Responses;

namespace Application.Wallets.Queries;

public class UpdateWalletQuery : IQuery<WalletResponse>
{
    public required string Id{ get; set; }
    public decimal Amount { get; set; }
}
using Application.Abstractions.Messaging;
using Application.Wallets.Responses;

namespace Application.Wallets.Queries;

public class GetWalletByClientIdQuery : IQuery<WalletResponse>
{
    public required string ClientId { get; set; }
}
using Application.Wallets.Queries;
using Application.Wallets.Responses;
using Domain;
using MediatR;

namespace Application.Wallets.Handlers;

public class GetWalletByClientIdHandler : IRequestHandler<GetWalletByClientIdQuery, WalletResponse>
{
    private readonly IWalletRepository _walletRepository;

    public GetWalletByClientIdHandler(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<WalletResponse> Handle(GetWalletByClientIdQuery query, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetByClientIdAsync(Guid.Parse(query.ClientId));
        return new WalletResponse
            { Id = wallet.Id.ToString(), ClientId = wallet.ClientId.ToString(), Amount = wallet.Amount, Currency = wallet.Currency };
    }
}
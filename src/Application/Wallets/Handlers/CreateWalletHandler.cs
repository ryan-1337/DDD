using Application.Wallets.Queries;
using Application.Wallets.Responses;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Wallets.Handlers;

public class CreateWalletHandler : IRequestHandler<CreateWalletQuery, WalletResponse>
{
    private readonly IWalletRepository _walletRepository;

    public CreateWalletHandler(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<WalletResponse> Handle(CreateWalletQuery query, CancellationToken cancellationToken)
    {
        var wallet = new Wallet(Guid.Parse(query.ClientId), query.Amount, query.Currency); 
        await _walletRepository.AddAsync(wallet);
        
        return new WalletResponse { Amount = query.Amount };
    }
}
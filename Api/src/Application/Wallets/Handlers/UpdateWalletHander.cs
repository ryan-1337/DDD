using Application.Wallets.Queries;
using Application.Wallets.Responses;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Wallets.Handlers;

public class UpdateWalletHander : IRequestHandler<UpdateWalletQuery, WalletResponse>
{
    private readonly IWalletRepository _walletRepository;

    public UpdateWalletHander(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<WalletResponse> Handle(UpdateWalletQuery query, CancellationToken cancellationToken)
    {
        var wallet = new Wallet{ClientId = Guid.Parse(query.ClientId), Amount = query.Amount, Currency = query.Currency};
        await _walletRepository.UpdateAsync(wallet);
        return new WalletResponse();
    }
}
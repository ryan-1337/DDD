using Application.Wallets.Queries;
using Application.Wallets.Responses;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Wallets.Handlers;

public class UpdateWalletHandler : IRequestHandler<UpdateWalletQuery, WalletResponse>
{
    private readonly IWalletRepository _walletRepository;

    public UpdateWalletHandler(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<WalletResponse> Handle(UpdateWalletQuery query, CancellationToken cancellationToken)
    {
        var wallet = new Wallet{Id = Guid.Parse(query.Id), Amount = query.Amount};
        await _walletRepository.UpdateAsync(wallet);
        return new WalletResponse();
    }
}
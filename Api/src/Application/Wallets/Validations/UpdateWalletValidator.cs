using Application.Wallets.Queries;
using FluentValidation;

namespace Application.Wallets.Validations;

public class UpdateWalletValidator : AbstractValidator<UpdateWalletQuery>
{
    public UpdateWalletValidator()
    {
        RuleFor(x => x.ClientId).NotEmpty();
    }
}
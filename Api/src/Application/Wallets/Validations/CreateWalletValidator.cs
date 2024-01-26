using Application.Wallets.Queries;
using FluentValidation;

namespace Application.Wallets.Validations;

public class CreateWalletValidator : AbstractValidator<CreateWalletQuery>
{
    public CreateWalletValidator()
    {
        RuleFor(x => x.ClientId).NotEmpty();
    }
}
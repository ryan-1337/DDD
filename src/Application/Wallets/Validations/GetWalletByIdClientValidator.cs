using Application.Wallets.Queries;
using FluentValidation;

namespace Application.Wallets.Validations;

public class GetWalletByIdClientValidator : AbstractValidator<GetWalletByClientIdQuery>
{
    public GetWalletByIdClientValidator()
    {
        RuleFor(x => x.ClientId).NotEmpty();
    }
}
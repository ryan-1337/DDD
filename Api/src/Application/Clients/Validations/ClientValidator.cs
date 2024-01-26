using Application.Clients.Queries;
using FluentValidation;

namespace Application.Clients.Validations;

public class ClientValidator : AbstractValidator<CreateClientQuery>
{
    public ClientValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MinimumLength(3).MaximumLength(20);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.PhoneNumber).NotEmpty().Length(10); 
    } 
}

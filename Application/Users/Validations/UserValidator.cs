using Application.Users.Queries;
using FluentValidation;

namespace Application.Users.Validations;

public class UserValidator : AbstractValidator<CreateUserQuery>
{
    public UserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(20);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Phone).NotEmpty().Length(10); 
    } 
}

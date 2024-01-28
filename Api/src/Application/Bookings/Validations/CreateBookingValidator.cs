using Application.Bookings.Queries;
using FluentValidation;

namespace Application.Bookings.Validations;

public class CreateBookingValidator : AbstractValidator<CreateBookingQuery>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.ClientId).NotEmpty();
    }
}
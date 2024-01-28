using Application.Bookings.Queries;
using FluentValidation;

namespace Application.Bookings.Validations;

public class UpdateBookingValidator : AbstractValidator<UpdateBookingQuery>
{
    public UpdateBookingValidator()
    {
        RuleFor(x => x.BookingId).NotEmpty();
        RuleFor(x => x.Status).NotEmpty();
    }
}
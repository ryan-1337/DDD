using Application.Abstractions.Messaging;
using Application.Payments.Responses;

namespace Application.Payments.Queries;

public class CreatePaymentQuery : IQuery<PaymentResponse>
{
    public required string ClientEmail { get; set; }
    public required decimal Amount { get; set; }
}
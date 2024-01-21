using Application.Payments.Queries;
using Application.Payments.Responses;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Payments.Handlers;

public class CreatePaymentHandler : IRequestHandler<CreatePaymentQuery, PaymentResponse>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IClientRepository _clientRepository;

    public CreatePaymentHandler(IPaymentRepository paymentRepository, IClientRepository clientRepository)
    {
        _paymentRepository = paymentRepository;
        _clientRepository = clientRepository;
    }

    public async Task<PaymentResponse> Handle(CreatePaymentQuery query, CancellationToken cancellationToken)
    {
        //_userValidator.ValidateAndThrow(query);
        var client = await _clientRepository.GetClientByEmail(query.ClientEmail);
    

        var paymentToCreate = new Payment(client, query.Amount, DateTime.Now);

        await _paymentRepository.SaveAsync(paymentToCreate);

        return new PaymentResponse { ClientId = client.Id.ToString(), Amount = paymentToCreate.Amount};
    }
}
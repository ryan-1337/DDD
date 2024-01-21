using Domain.Entities;

namespace Domain.Services;

public class PaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        this._paymentRepository = paymentRepository;
    }
    
    public async Task<Payment> ProcessPayment(Payment payment)
    {
        // Enregistrement de la transaction
        await _paymentRepository.SaveAsync(payment);
        return payment;
    }

    public decimal GetBalance(Client client)
    {
        // Calcul du solde en fonction des transactions de débit et de crédit
        //decimal debitAmount = paymentRepository.GetTotalAmountForClient(client, PaymentType.Debit);
        //decimal creditAmount = paymentRepository.GetTotalAmountForClient(client, PaymentType.Credit);

        //return creditAmount - debitAmount;
        return 0;
    }
}

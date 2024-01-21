using Domain.Entities;

namespace Domain.Services;

public class PaymentService
{
    private readonly IPaymentRepository paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        this.paymentRepository = paymentRepository;
    }
    
    public void ProcessPayment(Client client, decimal amount)
    {
        // Création d'une nouvelle transaction de paiement
        var payment = new Payment(client, amount, DateTime.UtcNow);

        // Enregistrement de la transaction
        paymentRepository.SaveAsync(payment);
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

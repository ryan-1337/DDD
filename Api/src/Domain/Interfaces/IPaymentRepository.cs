using Domain.Entities;

namespace Domain;

public interface IPaymentRepository
{

    public Task SaveAsync(Payment payment);
    public decimal GetTotalAmountForClient(Client client);
    public Task<List<Payment>> GetPaymentsForClient(Client client);
    
    
}
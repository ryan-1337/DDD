using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;


public class PaymentRepository : IPaymentRepository
{
    private readonly XyzHotelContext _xyzHotelContext;

    public PaymentRepository(XyzHotelContext xyzHotelContext)
    {
        this._xyzHotelContext = xyzHotelContext;
    }

    public async Task SaveAsync(Payment payment)
    {
        if (payment == null)
        {
            return;
        }
        
        var client = await _xyzHotelContext.Clients.FirstOrDefaultAsync(c => c.ID == payment.Client.Id.ToString());
        
        var paymentEntity = new DataAccess.XyzHotel.Payment
        {
            ID = payment.Id.ToString(),
            AMOUNT = payment.Amount,
            Client = client,
            TIMESTAMP = payment.Timestamp
        };
        
        await this._xyzHotelContext.Payments.AddAsync(paymentEntity);
        await this._xyzHotelContext.SaveChangesAsync();
    }

    public async Task<List<Payment>> GetPaymentsForClient(Client client)
    {
        var paymentsDB= this._xyzHotelContext.Payments.Where(payment => payment.Client.ID == client.Id.ToString()).ToList();
        var payments = paymentsDB.Select(x => new Payment(client, x.AMOUNT, x.TIMESTAMP)).ToList();
        return payments;
    }

    public decimal GetTotalAmountForClient(Client client)
    {
        return GetPaymentsForClient(client)
            .Result.Sum(payment => payment.Amount);
    }
}
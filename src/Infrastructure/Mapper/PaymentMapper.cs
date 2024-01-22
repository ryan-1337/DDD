using Infrastructure.DataAccess.XyzHotel;

namespace Infrastructure.Mapper;

public static class PaymentMapper
{
    public static Payment MapToDataAccess(Domain.Entities.Payment payment)
    {
        if (payment == null)
            return null;

        return new Payment
        {
            ID = payment.Id.ToString(),
            AMOUNT = payment.Amount,
            Client = ClientMapper.MapToDataAccess(payment.Client),
            TIMESTAMP = payment.Timestamp
        };
    }
    
    public static Domain.Entities.Payment MapToEntity(Payment paymentDataAccess)
    {
        if (paymentDataAccess == null)
            return null;

        return new Domain.Entities.Payment()
        {
            Id = Guid.Parse(paymentDataAccess.ID),
            Amount = paymentDataAccess.AMOUNT,
            Client = ClientMapper.MapToEntity(paymentDataAccess.Client),
            Timestamp = paymentDataAccess.TIMESTAMP
        };
    }
}

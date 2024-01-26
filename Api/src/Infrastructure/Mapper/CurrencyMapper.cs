using Infrastructure.DataAccess.XyzHotel;

namespace Infrastructure.Mapper;

public static class CurrencyMapper
{
    public static Currency MapToDataAccess(Domain.Entities.Currency currency)
    {
        if (currency == null)
            return null;

        return new Currency
        {
            CODE = currency.Code,
            NAME = currency.Name
        };
    }
}

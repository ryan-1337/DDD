using Domain.Entities;

namespace Domain.Services;

public class CurrencyConversionService
{
    public decimal ConvertAmount(decimal amount, Currency sourceCurrency, Currency targetCurrency)
    {
        if (sourceCurrency.Equals(targetCurrency))
        {
            return amount;
        }
        else
        {
            decimal convertedAmount = amount * (1 / sourceCurrency.ExchangeRateToEuro) * targetCurrency.ExchangeRateToEuro;
            return Math.Round(convertedAmount, 2);
        }
    }
}

using Domain.Entities;

namespace Domain.Services;

public class CurrencyConversionService
{
    private readonly Dictionary<string, decimal> exchangeRates;

    public CurrencyConversionService()
    {
        exchangeRates = new Dictionary<string, decimal>
        {
            { "EUR", 1.0m },
            { "USD", 1.18m },  
            { "GBP", 0.85m },  
            { "JPY", 130.5m }, 
            { "CHF", 1.08m }   
        };
    }

    public decimal ConvertAmount(decimal amount, string fromCurrency, string toCurrency)
    {
        if (!exchangeRates.ContainsKey(fromCurrency) || !exchangeRates.ContainsKey(toCurrency))
        {
            throw new ArgumentException("Devise non prise en charge");
        }

        decimal exchangeRate = exchangeRates[toCurrency] / exchangeRates[fromCurrency];
        return amount * exchangeRate;
    } 
}

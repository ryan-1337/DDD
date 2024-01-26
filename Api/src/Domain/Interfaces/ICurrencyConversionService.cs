namespace Domain;

public interface ICurrencyConversionService
{
    public decimal ConvertAmount(decimal amount, string fromCurrency, string toCurrency);
}
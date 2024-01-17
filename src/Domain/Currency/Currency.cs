namespace Domain;

public class Currency
{
    public string Code { get; }
    public string Name { get; }
    public decimal ExchangeRateToEuro { get; }

    private Currency(string code, string name, decimal exchangeRateToEuro)
    {
        Code = code;
        Name = name;
        ExchangeRateToEuro = exchangeRateToEuro;
    }

    public static Currency Euro => new Currency("EUR", "Euro", 1m);
    public static Currency Dollar => new Currency("USD", "Dollar", 1.18m); // Exemple, ajustez le taux de change
    public static Currency PoundSterling => new Currency("GBP", "Livre Sterling", 0.85m); // Exemple, ajustez le taux de change
    public static Currency Yen => new Currency("JPY", "Yen", 131.01m); // Exemple, ajustez le taux de change
    public static Currency SwissFranc => new Currency("CHF", "Franc Suisse", 1.08m); // Exemple, ajustez le taux de change

    public static Currency GetCurrencyByCode(string code)
    {
        switch (code.ToUpper())
        {
            case "EUR": return Euro;
            case "USD": return Dollar;
            case "GBP": return PoundSterling;
            case "JPY": return Yen;
            case "CHF": return SwissFranc;
            default: throw new ArgumentException("Invalid currency code.");
        }
    }
}
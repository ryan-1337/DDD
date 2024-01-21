namespace Domain.Entities;

public class Currency
{
    public Guid Id { get; }
    public string Code { get; }
    public string Name { get; }
    public decimal ExchangeRateToEuro { get; set; }

    public Currency(Guid id, string code, string name, decimal exchangeRateToEuro)
    {
        Id = id;
        Code = code;
        Name = name;
        ExchangeRateToEuro = exchangeRateToEuro;
    }

    public static Currency Euro => new Currency(Guid.NewGuid(), "EUR", "Euro", 1m);

}
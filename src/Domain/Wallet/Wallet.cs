namespace Domain;

public class Wallet
{
    public decimal Balance { get; private set; }
    public Currency Currency { get; private set; }

    private readonly List<Currency> acceptedCurrencies = new List<Currency> { Currency.Euro, Currency.Dollar, Currency.PoundSterling, Currency.Yen, Currency.SwissFranc };

    // Constructeur par défaut pour l'instanciation dans les tests
    private Wallet()
    {
    }

    public Wallet(decimal initialBalance, Currency currency)
    {
        ValidateCurrency(currency);

        Balance = initialBalance;
        Currency = currency;
    }

    public void Credit(decimal amount)
    {
        Balance += amount;
    }

    public void Debit(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }

        Balance -= amount;
    }

    private void ValidateCurrency(Currency currency)
    {
        if (!acceptedCurrencies.Contains(currency))
        {
            throw new ArgumentException("Invalid currency.");
        }
    }
}


namespace Domain.Entities;

public class Currency
{
    public Guid Id { get; }
    public string Code { get; }
    public string Name { get; }

    public Currency(Guid id, string code, string name)
    {
        Id = id;
        Code = code;
        Name = name;
    }

    public static Currency Euro => new Currency(Guid.NewGuid(), "EUR", "Euro");

}
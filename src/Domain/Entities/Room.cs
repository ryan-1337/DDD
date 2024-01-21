namespace Domain.Entities;

public class Room
{
    public string Name { get; }
    public decimal PricePerNight { get; }
    public List<string> Options { get; }

    public Room(string name, decimal pricePerNight, List<string> options)
    {
        Name = name;
        PricePerNight = pricePerNight;
        Options = options;
    }
}
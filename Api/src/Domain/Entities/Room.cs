namespace Domain.Entities;

public class Room
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal PricePerNight { get; set; }
    public List<string> Options { get; set; }

    public Room()
    {
        
    }
    
    public Room(string name, decimal pricePerNight, List<string> options)
    {
        Name = name;
        PricePerNight = pricePerNight;
        Options = options;
    }
}
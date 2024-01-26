namespace Application.Wallets.Responses;

public class RoomResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal PricePerNight { get; set; }
    public List<string> Options { get; set; }
}
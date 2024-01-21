namespace Infrastructure.DataAccess.XyzHotel;

public class Room
{
    public string ID { get; set; }
    public string NAME { get; set; }
    public decimal PRICE_PER_NIGHT { get; set; }
    public List<string>  OPTIONS { get; set; }   
 }
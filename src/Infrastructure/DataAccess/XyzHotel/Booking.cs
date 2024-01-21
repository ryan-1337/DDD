namespace Infrastructure.DataAccess.XyzHotel;

public class Booking
{
    public string ID { get; set; }
    public string CLIENT_ID { get; set; }
    public DateTime CHECK_IN_DATE { get; set; }
    public int NUMBER_OF_NIGHTS { get; set; }
    public Room ROOM { get; set; }
    public decimal TOTAL_AMOUNT { get; set; }
    public decimal INITIAL_PAYMENT { get; set; }
    public bool IS_CONFIRMED { get; private set; }
    public bool IS_CANCELLED { get; private set; }
}
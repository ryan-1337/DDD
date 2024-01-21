using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DataAccess.XyzHotel;

public class Payment
{
    public string ID { get; set; }
    public Client Client { get; set; }
    public decimal AMOUNT { get; set; }
    public DateTime TIMESTAMP { get; set; }
}
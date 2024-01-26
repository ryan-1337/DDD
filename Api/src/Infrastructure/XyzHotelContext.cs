using System.Text.Json;
using System.Text.Json.Serialization;
using Infrastructure.DataAccess.XyzHotel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class XyzHotelContext : DbContext
{
    public XyzHotelContext(DbContextOptions<XyzHotelContext> opt) : base(opt)
    {
        Database.EnsureCreated(); 
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var standardRoomFeatures = new List<string> { "Lit 1 place", "Wifi", "TV" };
        var superiorRoomFeatures = new List<string> { "Lit 2 places", "Wifi", "TV écran plat", "Minibar", "Climatiseur" };
        var suiteFeatures = new List<string> { "Lit 2 places", "Wifi", "TV écran plat", "Minibar", "Climatiseur", "Baignoire", "Terrasse" };


        modelBuilder.Entity<Currency>().HasData(
            new Currency { ID = "1", CODE = "EUR", NAME = "Euro" },
            new Currency { ID = "2", CODE = "USD", NAME = "Dollar" },
            new Currency { ID = "3", CODE = "GBP", NAME = "Livre Sterling" },
            new Currency { ID = "4", CODE = "JPY", NAME = "Yen" },
            new Currency { ID = "5", CODE = "CHF", NAME = "Franc Suisse" }
        );
        
        modelBuilder.Entity<Room>().HasData(
            new Room
            {
                ID = "1",
                NAME = "Standard",
                PRICE_PER_NIGHT = 50,
                OPTIONS = standardRoomFeatures
            },
            new Room
            {
                ID = "2",
                NAME = "Supérieure",
                PRICE_PER_NIGHT = 100,
                OPTIONS = superiorRoomFeatures
            },
            new Room
            {
                ID = "3",
                NAME = "Suite",
                PRICE_PER_NIGHT = 200,
                OPTIONS = suiteFeatures
            }
        ); 
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
}

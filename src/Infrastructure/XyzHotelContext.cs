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

        modelBuilder.Entity<Currency>().HasData(
            new Currency { ID = "1", CODE = "EUR", NAME = "Euro" },
            new Currency { ID = "2", CODE = "USD", NAME = "Dollar" },
            new Currency { ID = "3", CODE = "GBP", NAME = "Livre Sterling" },
            new Currency { ID = "4", CODE = "JPY", NAME = "Yen" },
            new Currency { ID = "5", CODE = "CHF", NAME = "Franc Suisse" }
        );
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
}

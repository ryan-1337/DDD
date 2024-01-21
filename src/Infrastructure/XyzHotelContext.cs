using Infrastructure.DataAccess.XyzHotel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class XyzHotelContext : DbContext
{
    public XyzHotelContext(DbContextOptions<XyzHotelContext> opt) : base(opt)
    {
        
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Payment> Payments { get; set; }
}

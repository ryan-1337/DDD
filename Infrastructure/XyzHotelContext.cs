using Infrastructure.DataAccess.XyzHotel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class XyzHotelContext : DbContext
{
    public XyzHotelContext(DbContextOptions<XyzHotelContext> opt) : base(opt)
    {
        
    }
    
    public DbSet<User> User { get; set; }
}

/*using Domain;
using Domain.Entities;

namespace Infrastructure.Repository;

public class BookingRepository : IBookingRepository
{
    private readonly XyzHotelContext _dbContext;

    public BookingRepository(XyzHotelContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task AddAsync(Booking booking)
    {
        await this._dbContext.Booking.AddAsync(booking);
        await this._dbContext.SaveChangesAsync();
    }

    public IEnumerable<Booking> GetAll()
    {
        return _dbContext.Bookings.ToList();
    }

    public IEnumerable<Booking> GetByClientId(Guid clientId)
    {
        return _dbContext.Bookings.Where(b => b.CLIENT_ID == clientId).ToList();
    }
}*/
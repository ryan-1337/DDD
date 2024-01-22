using Domain;
using Domain.Entities;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

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
        var bookingToAdd = BookingMapper.MapToDataAccess(booking);
        await this._dbContext.Bookings.AddAsync(bookingToAdd);
        await this._dbContext.SaveChangesAsync();
    }

    /*public IEnumerable<Booking> GetAll()
    {
        return _dbContext.Bookings.ToList();
    }*/
    
    public async Task<Booking> GetByIdAsync(Guid bookingId)
    {
        var booking = await _dbContext.Bookings
            .FirstOrDefaultAsync(b => b.ID == bookingId.ToString());

        return BookingMapper.MapToEntity(booking);
    }

    public async Task<IEnumerable<Booking>> GetByClientIdAsync(Guid clientId)
    {
        var bookings = await _dbContext.Bookings
            .Where(b => b.CLIENT_ID == clientId.ToString())
            .ToListAsync();

        return BookingMapper.MapToEntities(bookings);
    }
    
    public async Task UpdateAsync(Booking booking)
    {
        var existingBooking = await _dbContext.Bookings.FindAsync(booking.Id);

        if (existingBooking == null)
        {
            return;
        }

        var updatedBooking = BookingMapper.MapToDataAccess(booking, existingBooking);

        _dbContext.Entry(existingBooking).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
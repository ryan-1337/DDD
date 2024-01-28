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
        
        var room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.ID == booking.Room.Id);
        var bookingToCreate = new DataAccess.XyzHotel.Booking
        {
            ID = booking.Id.ToString(),
            CLIENT_ID = booking.ClientId.ToString(),
            CHECK_IN_DATE = booking.CheckInDate,
            NUMBER_OF_NIGHTS = booking.NumberOfNights,
            ROOM = room,
            IS_CONFIRMED = booking.IsConfirmed,
            IS_CANCELLED = booking.IsCancelled,
            INITIAL_PAYMENT = booking.InitialPayment,
            TOTAL_AMOUNT = booking.TotalAmount,
        };
        await this._dbContext.Bookings.AddAsync(bookingToCreate);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        var bookingsDataAccess = await _dbContext.Bookings
            .Include(r => r.ROOM)
            .ToListAsync();
        return BookingMapper.MapToEntities(bookingsDataAccess);
    }
    
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
        var existingBooking = await _dbContext.Bookings.FindAsync(booking.Id.ToString());

        if (existingBooking == null)
        {
            return;
        }

        var updatedBooking = BookingMapper.MapToDataAccess(booking, existingBooking);

        _dbContext.Entry(updatedBooking).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
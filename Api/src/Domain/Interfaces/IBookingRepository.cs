using Domain.Entities;

namespace Domain;

public interface IBookingRepository
{
    Task AddAsync(Booking booking);
    Task<IEnumerable<Booking>> GetAllAsync();
    //IEnumerable<Booking> GetByClientId(Guid clientId);
    Task<Booking> GetByIdAsync(Guid BookingId);
    Task<IEnumerable<Booking>> GetByClientIdAsync(Guid clientId);
    Task UpdateAsync(Booking booking);
}
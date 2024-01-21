using Domain.Entities;

namespace Domain;

public interface IBookingRepository
{
    void Add(Booking booking);
    IEnumerable<Booking> GetAll();
    IEnumerable<Booking> GetByClientId(Guid clientId);
}
using Domain.Entities;

namespace Domain;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetAllAsync();
    Task<Room> GetByIdAsync(Guid roomId);
}
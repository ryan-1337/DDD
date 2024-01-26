using Domain;
using Domain.Entities;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class RoomRepository : IRoomRepository
{
    private readonly XyzHotelContext _dbContext;

    public RoomRepository(XyzHotelContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    
    public async Task<IEnumerable<Room>> GetAllAsync()
    {
        var roomsDataAccess = await _dbContext.Rooms.ToListAsync();
        return RoomMapper.MapToListEntity(roomsDataAccess);
    }

    public async Task<Room> GetByIdAsync(string roomId)
    {
        var roomDataAccess = await _dbContext.Rooms
            .SingleOrDefaultAsync(r => r.ID == roomId);

        return RoomMapper.MapToEntity(roomDataAccess);
    }
}

using Infrastructure.DataAccess.XyzHotel;

namespace Infrastructure.Mapper;

public static class RoomMapper
{
    public static Room MapToDataAccess(Domain.Entities.Room room)
    {
        if (room == null)
            return null;

        return new Room()
        {
            ID = room.Id.ToString(),
            NAME = room.Name,
            PRICE_PER_NIGHT = room.PricePerNight,
            OPTIONS = room.Options,
        };
    }
    
    public static Domain.Entities.Room MapToEntity(Room roomDataAccess)
    {
        if (roomDataAccess == null)
            return null;

        return new Domain.Entities.Room()
        {
            Id = Guid.Parse(roomDataAccess.ID),
            Name = roomDataAccess.NAME,
            PricePerNight = roomDataAccess.PRICE_PER_NIGHT,
            Options = roomDataAccess.OPTIONS
        };
    }
}
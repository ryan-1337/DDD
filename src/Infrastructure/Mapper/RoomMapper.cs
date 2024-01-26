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
            ID = room.Id,
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
            Id = roomDataAccess.ID,
            Name = roomDataAccess.NAME,
            PricePerNight = roomDataAccess.PRICE_PER_NIGHT,
            Options = roomDataAccess.OPTIONS
        };
    }
    
    public static List<Domain.Entities.Room> MapToListEntity(List<Room> roomsDataAccess)
    {
        if (roomsDataAccess == null)
            return null;

        return roomsDataAccess.Select(roomDataAccess => new Domain.Entities.Room
        {
            Id = roomDataAccess.ID,
            Name = roomDataAccess.NAME,
            PricePerNight = roomDataAccess.PRICE_PER_NIGHT,
            Options = roomDataAccess.OPTIONS
        }).ToList();
    }
}
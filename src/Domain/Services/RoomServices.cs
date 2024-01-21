using Domain.Entities;

namespace Domain.Services;

public class RoomService
{
    public List<Room> GetAvailableRoomTypes()
    {
        var room = new List<Room>
        {
            new Room("Chambre standard", 50m, new List<string> { "Lit 1 place", "Wifi", "TV" }),
            new Room("Chambre supérieure", 100m, new List<string> { "Lit 2 places", "Wifi", "TV écran plat", "Minibar", "Climatiseur" }),
            new Room("Suite", 200m, new List<string> { "Lit 2 places", "Wifi", "TV écran plat", "Minibar", "Climatiseur", "Baignoire", "Terrasse" })
        };

        return room;
    }
}
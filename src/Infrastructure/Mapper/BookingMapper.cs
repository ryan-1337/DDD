using Infrastructure.DataAccess.XyzHotel;

namespace Infrastructure.Mapper;

public static class BookingMapper
{
    public static Booking MapToDataAccess(Domain.Entities.Booking booking)
    {
        if (booking == null)
            return null;
        
        return new Booking
        {
            ID = booking.Id.ToString(),
            CLIENT_ID = booking.ClientId.ToString(),
            CHECK_IN_DATE = booking.CheckInDate,
            NUMBER_OF_NIGHTS = booking.NumberOfNights,
            ROOM = RoomMapper.MapToDataAccess(booking.Room),
            TOTAL_AMOUNT = booking.TotalAmount,
            INITIAL_PAYMENT = booking.InitialPayment,
            IS_CONFIRMED = booking.IsConfirmed,
            IS_CANCELLED = booking.IsCancelled
        };
    }
    
    public static Domain.Entities.Booking MapToEntity(Booking bookingDataAccess)
    {
        if (bookingDataAccess == null)
            return null;

        return new Domain.Entities.Booking
        {
            Id = Guid.Parse(bookingDataAccess.ID),
            ClientId = Guid.Parse(bookingDataAccess.CLIENT_ID),
            CheckInDate = bookingDataAccess.CHECK_IN_DATE,
            NumberOfNights = bookingDataAccess.NUMBER_OF_NIGHTS,
            Room = RoomMapper.MapToEntity(bookingDataAccess.ROOM), 
            TotalAmount = bookingDataAccess.TOTAL_AMOUNT,
            InitialPayment = bookingDataAccess.INITIAL_PAYMENT,
            IsConfirmed = bookingDataAccess.IS_CONFIRMED,
            IsCancelled = bookingDataAccess.IS_CANCELLED
        };
    } 
    
    public static List<Domain.Entities.Booking> MapToEntities(List<Booking> bookingDataAccessList)
    {
        if (bookingDataAccessList == null)
            return null;

        return bookingDataAccessList.Select(MapToListEntity).ToList();
    }

    public static Domain.Entities.Booking MapToListEntity(Booking bookingDataAccess)
    {
        if (bookingDataAccess == null)
            return null;

        return new Domain.Entities.Booking()
        {
            Id = Guid.Parse(bookingDataAccess.ID),
            ClientId = Guid.Parse(bookingDataAccess.CLIENT_ID),
            CheckInDate = bookingDataAccess.CHECK_IN_DATE,
            NumberOfNights = bookingDataAccess.NUMBER_OF_NIGHTS,
            Room = RoomMapper.MapToEntity(bookingDataAccess.ROOM),
            TotalAmount = bookingDataAccess.TOTAL_AMOUNT,
            InitialPayment = bookingDataAccess.INITIAL_PAYMENT,
            IsConfirmed = bookingDataAccess.IS_CONFIRMED,
            IsCancelled = bookingDataAccess.IS_CANCELLED
        };
    }
    
    public static DataAccess.XyzHotel.Booking MapToDataAccess(Domain.Entities.Booking entity, DataAccess.XyzHotel.Booking dataAccess = null)
    {
        if (dataAccess == null)
        {
            dataAccess = new DataAccess.XyzHotel.Booking();
        }

        dataAccess.ID = entity.Id.ToString();
        dataAccess.CLIENT_ID = entity.ClientId.ToString();
        dataAccess.CHECK_IN_DATE = entity.CheckInDate;
        dataAccess.NUMBER_OF_NIGHTS = entity.NumberOfNights;
        dataAccess.TOTAL_AMOUNT = entity.TotalAmount;
        dataAccess.INITIAL_PAYMENT = entity.InitialPayment;
        dataAccess.IS_CONFIRMED = entity.IsConfirmed;
        dataAccess.IS_CANCELLED = entity.IsCancelled;

        return dataAccess;
    } 
}

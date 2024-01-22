using Domain.Entities;
using Infrastructure.DataAccess.XyzHotel;
using Client = Infrastructure.DataAccess.XyzHotel.Client;

namespace Infrastructure.Mapper;

public static class ClientMapper
{
    public static DataAccess.XyzHotel.Client MapToDataAccess(Domain.Entities.Client client)
    {
        if (client == null)
            return null;

        return new Client
        {
            ID = client.Id.ToString(),
            FULLNAME = client.FullName,
            EMAIL = client.Email,
            PHONENUMBER = client.PhoneNumber
        };
    }
    
    public static Domain.Entities.Client MapToEntity(DataAccess.XyzHotel.Client clientDataAccess)
    {
        if (clientDataAccess == null)
            return null;

        return new Domain.Entities.Client()
        {
            Id = Guid.Parse(clientDataAccess.ID),
            FullName = clientDataAccess.FULLNAME,
            Email = clientDataAccess.EMAIL,
            PhoneNumber = clientDataAccess.PHONENUMBER
        };
    }
}
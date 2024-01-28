using Domain;
using Domain.Entities;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ClientRepository : IClientRepository
{
    private readonly XyzHotelContext _xyzHotelContext;

    public ClientRepository(XyzHotelContext xyzHotelContext)
    {
        this._xyzHotelContext = xyzHotelContext;
    }
    
    public async Task<Client> AddAsync(Client client)
    {
        var clientDataAccess = new DataAccess.XyzHotel.Client
        {
            ID = client.Id.ToString(),
            FULLNAME = client.FullName,
            EMAIL = client.Email,
            PHONENUMBER = client.PhoneNumber
        };

        await _xyzHotelContext.Clients.AddAsync(clientDataAccess);
        await _xyzHotelContext.SaveChangesAsync();

        return ClientMapper.MapToEntity(clientDataAccess);
    }
    
    public async Task<Client?> GetClientById(string id)
    {
        var clientDataAccess = await _xyzHotelContext.Clients
            .FirstOrDefaultAsync(x => x.ID == id);
    
        return clientDataAccess != null ? ClientMapper.MapToEntity(clientDataAccess) : null;
    }

    public async Task<Client?> GetClientByFullName(string fullName)
    {
        var clientDataAccess = await _xyzHotelContext.Clients
            .FirstOrDefaultAsync(x => x.FULLNAME == fullName);

        return clientDataAccess != null ? ClientMapper.MapToEntity(clientDataAccess) : null;
    }

    public async Task<Client?> GetClientByEmail(string email)
    {
        var clientDataAccess = await _xyzHotelContext.Clients
            .FirstOrDefaultAsync(x => x.EMAIL == email);

        return clientDataAccess != null ? ClientMapper.MapToEntity(clientDataAccess) : null;
    }

    public async Task<bool> IsEmailAlreadyUsedAsync(string email)
    {
        return await _xyzHotelContext.Clients.AnyAsync(client => client.EMAIL == email);
    }

}

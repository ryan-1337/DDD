using Domain;
using Domain.Entities;
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
        await this._xyzHotelContext.Clients.AddAsync(new DataAccess.XyzHotel.Client
        {
            ID = client.Id.ToString(), 
            FULLNAME = client.FullName, 
            EMAIL = client.Email, 
            PHONENUMBER = client.PhoneNumber
        });
        
        await this._xyzHotelContext.SaveChangesAsync();

        return client;
    }

    public async Task<Client?> GetClientByFullName(string fullName)
    {
        var client = await this._xyzHotelContext.Clients.FirstOrDefaultAsync(x => x.FULLNAME == fullName);
        return new Client(Guid.Parse(client.ID), client.FULLNAME, client.EMAIL, client.PHONENUMBER);
    }
    
    public async Task<Client?> GetClientByEmail(string email)
    {
        var client = await this._xyzHotelContext.Clients.FirstOrDefaultAsync(x => x.EMAIL == email);
        return new Client(Guid.Parse(client.ID), client.FULLNAME, client.EMAIL, client.PHONENUMBER);
    }
    
    public bool IsEmailAlreadyUsed(string email)
    {
        return _xyzHotelContext.Clients.Any(client => client.EMAIL == email);
    }
}

using Domain;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly XyzHotelContext _xyzHotelContext;

    public UserRepository(XyzHotelContext xyzHotelContext)
    {
        this._xyzHotelContext = xyzHotelContext;
    }
    
    public async Task<User?> AddAsync(User user)
    {
        if (user == null)
        {
            return null;
        }

        var userToAdd = await this._xyzHotelContext.User.AddAsync(new DataAccess.XyzHotel.User{ID = user.Id, USERNAME = user.Name, EMAIL = user.Email, PHONE = user.Phone });
        await this._xyzHotelContext.SaveChangesAsync();

        return user;
    }
}

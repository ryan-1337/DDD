namespace Domain;

public interface IUserRepository
{
    Task<User?> AddAsync(User user);
}

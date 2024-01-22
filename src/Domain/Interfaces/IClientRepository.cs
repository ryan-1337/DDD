using Domain.Entities;

namespace Domain;

public interface IClientRepository
{
    Task<Client> AddAsync(Client user);
    Task<Client?> GetClientByFullName(string fullName);
    Task<Client?> GetClientByEmail(string email);
    Task<bool> IsEmailAlreadyUsedAsync(string email);
}

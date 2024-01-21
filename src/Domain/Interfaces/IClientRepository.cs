using Domain.Entities;

namespace Domain;

public interface IClientRepository
{
    Task<Client> AddAsync(Client user);
    Task<Client?> GetClientByFullName(string fullName);
    Task<Client?> GetClientByEmail(string email);
    bool IsEmailAlreadyUsed(string email);
}

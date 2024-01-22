using Application.Clients.Queries;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Clients.Handlers;

public class CreateClientHandler : IRequestHandler<CreateClientQuery, ClientResponse>
{
    private readonly IClientRepository _clientRepository;

    public CreateClientHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ClientResponse> Handle(CreateClientQuery query, CancellationToken cancellationToken)
    {

        if (await _clientRepository.IsEmailAlreadyUsedAsync(query.Email))
        {
            throw new InvalidOperationException("L'adresse e-mail est déjà utilisée.");
        }

        var clientToCreate = new Client(Guid.NewGuid(), query.FullName, query.Email, query.PhoneNumber);
        
        var client = await _clientRepository.AddAsync(clientToCreate);

        return new ClientResponse { Id = client.Id.ToString(), Name = client.FullName, Email = client.Email, Phone = client.PhoneNumber };
    }
}

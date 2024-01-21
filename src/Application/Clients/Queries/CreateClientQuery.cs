using Application.Abstractions.Messaging;
using MediatR;

namespace Application.Clients.Queries;
public class CreateClientQuery : IQuery<ClientResponse>
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public string PhoneNumber { get; set; }
}
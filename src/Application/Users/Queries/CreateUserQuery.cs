using Application.Abstractions.Messaging;
using MediatR;

namespace Application.Users.Queries;
public class CreateUserQuery : IQuery<UserResponse>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string Phone { get; set; }
}
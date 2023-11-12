using MediatR;

namespace Application.Users.Queries;

public class CreateUserQuery : IRequest<UserResponse>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public int Phone { get; set; }
}

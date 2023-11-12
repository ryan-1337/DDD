using Application.Users.Queries;
using Application.Users.Validations;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Users.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<CreateUserQuery> _userValidator;

    public CreateUserHandler(IUserRepository userRepository, IValidator<CreateUserQuery> userValidator)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
    }

    public async Task<UserResponse> Handle(CreateUserQuery query, CancellationToken cancellationToken)
    {
        _userValidator.ValidateAndThrow(query);
        
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = query.Name, 
            Email = query.Email,
            Phone = query.Phone
        };
        
        await _userRepository.AddAsync(user);

        return new UserResponse { Id = user.Id, Name = user.Name, Email = user.Email, Phone = user.Phone };
    }
}

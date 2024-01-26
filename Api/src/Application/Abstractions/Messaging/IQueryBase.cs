using MediatR;

namespace Application.Abstractions.Messaging;

public interface IQuery : IRequest, IQueryBase
{
}

public interface IQuery<TResponse> : IRequest<TResponse>, IQueryBase
{
}

public interface IQueryBase
{
}
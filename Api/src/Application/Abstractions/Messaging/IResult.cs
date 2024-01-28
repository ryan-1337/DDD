namespace Application.Abstractions.Messaging;

public interface IResult<T>
{
    T Data { get; }
    bool IsSuccess { get; }
    string ErrorMessage { get; }
    int? StatusCode { get; }
}
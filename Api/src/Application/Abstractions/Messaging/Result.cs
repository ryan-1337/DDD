using Application.Abstractions.Messaging;

public class Result<T> : IResult<T>
{
    public T Data { get; private set; }
    public bool IsSuccess { get; private set; }
    public string ErrorMessage { get; private set; }
    public int? StatusCode { get; private set; }

    private Result(T data, bool isSuccess, string errorMessage, int? statusCode)
    {
        Data = data;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }

    public static IResult<T> Success(T data)
    {
        return new Result<T>(data, true, null, null);
    }

    public static IResult<T> Failure(string errorMessage, int? statusCode = null)
    {
        return new Result<T>(default(T), false, errorMessage, statusCode);
    }
}
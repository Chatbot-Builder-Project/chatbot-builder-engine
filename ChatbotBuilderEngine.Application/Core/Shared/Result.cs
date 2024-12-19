using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Application.Core.Shared;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    public IReadOnlyList<ValidationError> ValidationErrors { get; }

    protected Result(
        bool isSuccess,
        Error error,
        IReadOnlyList<ValidationError> validationErrors)
    {
        switch (isSuccess)
        {
            case true when error != Error.None:
                throw new InvalidOperationException("A successful result cannot have an error.");
            case false when error == Error.None:
                throw new InvalidOperationException("A failure result must have an error.");
        }

        IsSuccess = isSuccess;
        Error = error;
        ValidationErrors = validationErrors;
    }

    public static Result Success() => new(true, Error.None, []);

    public static Result Failure(Error error) => new(false, error, []);

    public static Result ValidationFailure(
        string code,
        string message,
        IReadOnlyList<ValidationError> validationErrors)
    {
        return new Result(false, Error.ApplicationValidation(code, message), validationErrors);
    }

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None, []);

    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error, []);

    public static Result<TValue> ValidationFailure<TValue>(
        string code,
        string message,
        IReadOnlyList<ValidationError> validationErrors)
    {
        return new Result<TValue>(default, false, Error.ApplicationValidation(code, message), validationErrors);
    }
}

public sealed class Result<TValue> : Result
{
    private readonly TValue? _value;

    internal Result(
        TValue? value,
        bool isSuccess,
        Error error,
        IReadOnlyList<ValidationError> validationErrors)
        : base(isSuccess, error, validationErrors)
    {
        _value = value;
    }

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result cannot be accessed.");
}
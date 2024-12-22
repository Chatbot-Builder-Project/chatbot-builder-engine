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
}

public sealed class Result<TValue> : Result
{
    public TValue? Value { get; }

    private Result(
        TValue? value,
        bool isSuccess,
        Error error,
        IReadOnlyList<ValidationError> validationErrors)
        : base(isSuccess, error, validationErrors)
    {
        Value = value;
    }

    public static Result<TValue> Success(TValue value) =>
        new(value, true, Error.None, []);

    public new static Result<TValue> Failure(Error error) =>
        new(default, false, error, []);

    public new static Result<TValue> ValidationFailure(
        string code,
        string message,
        IReadOnlyList<ValidationError> validationErrors)
    {
        return new Result<TValue>(default, false, Error.ApplicationValidation(code, message), validationErrors);
    }
}
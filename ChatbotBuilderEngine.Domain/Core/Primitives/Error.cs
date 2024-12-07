namespace ChatbotBuilderEngine.Domain.Core.Primitives;

public class Error : ValueObject
{
    public ErrorType Type { get; }
    public string Code { get; }
    public string Message { get; }

    public Error(ErrorType type, string code, string message)
    {
        Type = type;
        Code = code;
        Message = message;
    }

    public static implicit operator string(Error? error) => error?.Code ?? string.Empty;

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Type;
        yield return Code;
        yield return Message;
    }

    public static readonly Error None = new(
        ErrorType.None,
        string.Empty,
        string.Empty);

    public static readonly Error NullValue = new(
        ErrorType.BadRequest,
        "Error.NullValue",
        "The specified result value is null.");
}

public enum ErrorType
{
    None = 0,
    BadRequest = 1,
    NotFound = 2,
    NotAuthorized = 3,
    Conflict = 4,
    InternalServerError = 5,
    Forbidden = 6,
    TooManyRequests = 7
}
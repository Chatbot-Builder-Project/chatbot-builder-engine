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
}

public enum ErrorType
{
    None,
    DomainValidation,
    BusinessRuleViolation,
    ResourceConflict,
    DependencyError
}
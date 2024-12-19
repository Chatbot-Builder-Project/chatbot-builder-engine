namespace ChatbotBuilderEngine.Domain.Core.Primitives;

public sealed class Error : ValueObject
{
    public ErrorType Type { get; } = ErrorType.None;
    public string Code { get; } = string.Empty;
    public string Message { get; } = string.Empty;

    private Error(ErrorType type, string code, string message)
    {
        Type = type;
        Code = code;
        Message = message;
    }

    /// <inheritdoc/>
    private Error()
    {
    }

    public static implicit operator string(Error? error) => error?.Code ?? string.Empty;

    /// <inheritdoc/>
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

    public static Error DomainValidation(string code, string message) => new(
        ErrorType.DomainValidation,
        code,
        message);

    public static Error ApplicationValidation(string code, string message) => new(
        ErrorType.ApplicationValidation,
        code,
        message);

    public static Error BusinessRuleViolation(string code, string message) => new(
        ErrorType.BusinessRuleViolation,
        code,
        message);

    public static Error ResourceConflict(string code, string message) => new(
        ErrorType.ResourceConflict,
        code,
        message);

    public static Error DependencyError(string code, string message) => new(
        ErrorType.DependencyError,
        code,
        message);
}

public enum ErrorType
{
    None,
    DomainValidation,
    ApplicationValidation,
    BusinessRuleViolation,
    ResourceConflict,
    DependencyError
}
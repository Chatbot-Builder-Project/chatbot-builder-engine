namespace ChatbotBuilderEngine.Application.Core.Shared;

public sealed class ValidationError
{
    public string Field { get; }
    public string Message { get; }

    public ValidationError(string field, string message)
    {
        Field = field;
        Message = message;
    }
}
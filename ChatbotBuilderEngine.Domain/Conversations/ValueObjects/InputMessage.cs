using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Interactions;

namespace ChatbotBuilderEngine.Domain.Conversations.ValueObjects;

public sealed class InputMessage : ValueObject
{
    public DateTime CreatedAt { get; }
    public InteractionInput Input { get; } = null!;

    private InputMessage(DateTime createdAt, InteractionInput input)
    {
        CreatedAt = createdAt;
        Input = input;
    }

    /// <inheritdoc/>
    private InputMessage()
    {
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CreatedAt;
        yield return Input;
    }

    public static InputMessage Create(InteractionInput input) => new(DateTime.UtcNow, input);
}
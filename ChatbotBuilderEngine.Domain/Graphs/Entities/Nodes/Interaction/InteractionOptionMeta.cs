using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes.Interaction;

/// <summary>
/// Meta information for an OptionData used in an Interaction node
/// </summary>
public sealed class InteractionOptionMeta : ValueObject
{
    public string Description { get; } = null!;

    private InteractionOptionMeta(string description)
    {
        Description = description;
    }

    public static InteractionOptionMeta Create(string description) => new(description);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Description;
    }
}
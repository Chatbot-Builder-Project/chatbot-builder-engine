using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

/// <remarks>
/// Corresponds to Component base class in upper layers.
/// </remarks>
public sealed class InfoMeta : ValueObject
{
    public int Identifier { get; }
    public string Name { get; }

    private InfoMeta(int identifier, string name)
    {
        Identifier = identifier;
        Name = name;
    }

    public static InfoMeta Create(int identifier, string name) => new(identifier, name);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Identifier;
        yield return Name;
    }
}
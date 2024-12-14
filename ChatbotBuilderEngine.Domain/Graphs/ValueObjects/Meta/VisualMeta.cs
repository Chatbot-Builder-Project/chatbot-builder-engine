using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

/// <remarks>
/// Corresponds to VisualComponent base class in upper layers.
/// </remarks>
public sealed class VisualMeta : ValueObject
{
    public float X { get; }
    public float Y { get; }

    private VisualMeta(float x, float y)
    {
        X = x;
        Y = y;
    }

    /// <inheritdoc/>
    private VisualMeta()
    {
    }

    public static VisualMeta Create(float x, float y) => new(x, y);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return X;
        yield return Y;
    }
}
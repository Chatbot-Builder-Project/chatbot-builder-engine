using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract;

public abstract class Link<TId> : Entity<TId>
    where TId : EntityId<TId>
{
    public InfoMeta Info { get; } = null!;
    public VisualMeta Visual { get; } = null!;

    protected Link(
        TId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual)
        : base(id, createdAt, updatedAt)
    {
        Info = info;
        Visual = visual;
    }

    /// <inheritdoc/>
    protected Link()
    {
    }
}
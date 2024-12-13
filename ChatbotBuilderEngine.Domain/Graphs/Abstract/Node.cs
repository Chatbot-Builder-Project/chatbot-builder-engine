using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract;

public abstract class Node : Entity<NodeId>
{
    public InfoMeta Info { get; } = null!;
    public VisualMeta Visual { get; } = null!;

    protected Node(
        NodeId id,
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
    protected Node()
    {
    }
}
using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract;

public abstract class Port<TId> : Entity<TId>
    where TId : EntityId<TId>
{
    public InfoMeta Info { get; } = null!;
    public VisualMeta Visual { get; } = null!;
    public NodeId NodeId { get; } = null!;

    protected Port(
        TId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        NodeId nodeId)
        : base(id, createdAt, updatedAt)
    {
        Info = info;
        Visual = visual;
        NodeId = nodeId;
    }

    /// <inheritdoc/>
    protected Port()
    {
    }

    public void EnsureNodeIdIs(NodeId nodeId)
    {
        if (NodeId != nodeId)
        {
            throw new DomainException(GraphsDomainErrors.Port.NodeIdMismatch);
        }
    }
}
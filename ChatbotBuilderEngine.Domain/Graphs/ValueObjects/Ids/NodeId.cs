using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

public sealed class NodeId : EntityId<NodeId>
{
    public NodeId(Guid value) : base(value)
    {
    }
}
using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

public sealed class GraphId : EntityId<GraphId>
{
    public GraphId(Guid value) : base(value)
    {
    }
}
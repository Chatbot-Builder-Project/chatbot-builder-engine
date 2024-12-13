using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

public sealed class FlowLinkId : EntityId<FlowLinkId>
{
    public FlowLinkId(Guid value) : base(value)
    {
    }
}
using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

public sealed class OutputPortId : EntityId<OutputPortId>
{
    public OutputPortId(Guid value) : base(value)
    {
    }
}
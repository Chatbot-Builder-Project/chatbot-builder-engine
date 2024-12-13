using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

public sealed class InputPortId : EntityId<InputPortId>
{
    public InputPortId(Guid value) : base(value)
    {
    }
}
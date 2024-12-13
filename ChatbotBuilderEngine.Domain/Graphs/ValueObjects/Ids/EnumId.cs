using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

public sealed class EnumId : EntityId<EnumId>
{
    public EnumId(Guid value) : base(value)
    {
    }
}
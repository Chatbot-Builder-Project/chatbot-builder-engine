using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

public sealed class DataLinkId : EntityId<DataLinkId>
{
    public DataLinkId(Guid value) : base(value)
    {
    }
}
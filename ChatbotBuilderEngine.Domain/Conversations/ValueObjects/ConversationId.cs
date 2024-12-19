using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Conversations.ValueObjects;

public sealed class ConversationId : EntityId<ConversationId>
{
    public ConversationId(Guid value) : base(value)
    {
    }
}
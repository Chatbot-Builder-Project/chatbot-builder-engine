using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;

public sealed class ChatbotId : EntityId<ChatbotId>
{
    public ChatbotId(Guid value) : base(value)
    {
    }
}
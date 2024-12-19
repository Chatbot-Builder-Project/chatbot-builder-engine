using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Conversations;

public static class ConversationsDomainErrors
{
    public static class Conversation
    {
        public static readonly Error InputMessageIsOutOfOrder = new(
            ErrorType.DomainValidation,
            "Conversation.InputMessageIsOutOfOrder",
            "Input message is out of order");

        public static readonly Error OutputMessageIsOutOfOrder = new(
            ErrorType.DomainValidation,
            "Conversation.OutputMessageIsOutOfOrder",
            "Output message is out of order");
    }
}
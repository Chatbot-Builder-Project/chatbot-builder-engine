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

    public static class ConversationFlow
    {
        public static readonly Error GraphMismatch = new(
            ErrorType.DomainValidation,
            "ConversationFlow.GraphMismatch",
            "Conversation graph mismatch");

        public static readonly Error ConversationNotSet = new(
            ErrorType.DomainValidation,
            "ConversationFlow.ConversationNotSet",
            "Conversation not set");

        public static readonly Error NodeIsNotAnInteractionNode = new(
            ErrorType.DomainValidation,
            "Conversation.NodeIsNotAnInteractionNode",
            "Node is not an interaction node");
    }
}
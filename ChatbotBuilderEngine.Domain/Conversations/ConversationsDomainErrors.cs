using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Conversations;

public static class ConversationsDomainErrors
{
    public static class Conversation
    {
        public static readonly Error InputMessageIsOutOfOrder = Error.DomainValidation(
            "Conversation.InputMessageIsOutOfOrder",
            "Input message is out of order");

        public static readonly Error OutputMessageIsOutOfOrder = Error.DomainValidation(
            "Conversation.OutputMessageIsOutOfOrder",
            "Output message is out of order");
    }

    public static class ConversationFlow
    {
        public static readonly Error GraphMismatch = Error.DomainValidation(
            "ConversationFlow.GraphMismatch",
            "Conversation graph mismatch");

        public static readonly Error ConversationNotSet = Error.DomainValidation(
            "ConversationFlow.ConversationNotSet",
            "Conversation not set");

        public static readonly Error NodeIsNotAnInteractionNode = Error.DomainValidation(
            "Conversation.NodeIsNotAnInteractionNode",
            "Node is not an interaction node");
    }
}
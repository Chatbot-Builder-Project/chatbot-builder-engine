using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Application.Conversations;

public static class ConversationsApplicationErrors
{
    public static readonly Error ChatbotNotFound = Error.ApplicationValidation(
        "Conversations.ChatbotNotFound",
        "Chatbot not found.");

    public static readonly Error ConversationNotFound = Error.ApplicationValidation(
        "Conversations.ConversationNotFound",
        "Conversation not found.");
}
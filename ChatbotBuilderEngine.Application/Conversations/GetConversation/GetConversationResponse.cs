using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderEngine.Application.Conversations.GetConversation;

public sealed record GetConversationResponse(
    ConversationId Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    ChatbotId ChatbotId);
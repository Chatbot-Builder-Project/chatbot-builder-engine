using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderEngine.Application.Conversations.StartConversation;

public sealed record StartConversationResponse(
    ConversationId ConversationId,
    OutputMessage InitialMessage);
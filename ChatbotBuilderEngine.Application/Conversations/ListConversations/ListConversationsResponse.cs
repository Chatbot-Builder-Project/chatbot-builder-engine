using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderEngine.Application.Conversations.ListConversations;

public sealed record ListConversationsResponse(PageResponse<ListConversationResponseItem> Page);

public sealed record ListConversationResponseItem(
    ConversationId Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    ChatbotId ChatbotId);
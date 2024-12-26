using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Chatbots.ListChatbots;

public sealed record ListChatbotsResponse(PageResponse<ListChatbotsResponseItem> Page);

public sealed record ListChatbotsResponseItem(
    ChatbotId Id,
    UserId OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    bool IsPublic);
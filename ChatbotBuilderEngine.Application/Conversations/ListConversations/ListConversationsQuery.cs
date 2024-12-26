using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Conversations.ListConversations;

public sealed class ListConversationsQuery : IQuery<ListConversationsResponse>
{
    public required PageParams PageParams { get; init; }
    public required UserId UserId { get; init; }
    public string? Search { get; init; }
    public ChatbotId? ChatbotId { get; init; }
}
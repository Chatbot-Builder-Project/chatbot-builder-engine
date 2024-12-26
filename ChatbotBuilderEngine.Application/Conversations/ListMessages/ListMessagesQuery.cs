using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Conversations.ListMessages;

public sealed class ListMessagesQuery : IQuery<ListMessagesResponse>
{
    public required ConversationId ConversationId { get; init; }
    public required UserId UserId { get; init; }
    public required PageParams PageParams { get; init; }
}
using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Conversations.GetConversation;

public sealed class GetConversationQuery : IQuery<GetConversationResponse>
{
    public required ConversationId Id { get; init; }
    public required UserId UserId { get; init; }
}
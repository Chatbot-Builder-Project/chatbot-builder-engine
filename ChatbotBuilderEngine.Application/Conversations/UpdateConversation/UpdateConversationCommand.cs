using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Conversations.UpdateConversation;

public sealed class UpdateConversationCommand : ICommand
{
    public required ConversationId Id { get; init; }
    public required UserId UserId { get; init; }
    public required string Name { get; init; }
}
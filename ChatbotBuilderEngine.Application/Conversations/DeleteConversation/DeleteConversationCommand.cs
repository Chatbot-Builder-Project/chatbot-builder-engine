using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Conversations.DeleteConversation;

public sealed class DeleteConversationCommand : ICommand
{
    public required ConversationId Id { get; init; }
    public required UserId OwnerId { get; init; }
}
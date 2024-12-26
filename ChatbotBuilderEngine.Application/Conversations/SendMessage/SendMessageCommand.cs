using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Conversations.SendMessage;

public sealed class SendMessageCommand : ICommand<SendMessageResponse>
{
    public required ConversationId ConversationId { get; init; }
    public required UserId UserId { get; init; }
    public required InputMessage InputMessage { get; init; }
}
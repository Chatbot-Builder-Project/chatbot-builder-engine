using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Conversations.StartConversation;

public sealed class StartConversationCommand : ICommand<StartConversationResponse>
{
    public required ChatbotId ChatbotId { get; init; }
    public required UserId UserId { get; init; }
    public required string Name { get; init; }
}
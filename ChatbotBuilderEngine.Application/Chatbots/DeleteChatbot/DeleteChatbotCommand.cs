using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Chatbots.DeleteChatbot;

public sealed class DeleteChatbotCommand : ICommand
{
    public required ChatbotId Id { get; init; }
    public required UserId OwnerId { get; init; }
}
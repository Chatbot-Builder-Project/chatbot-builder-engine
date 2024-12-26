using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Chatbots.GetChatbot;

public sealed class GetChatbotQuery : IQuery<GetChatbotResponse>
{
    public required ChatbotId Id { get; init; }
    public required UserId UserId { get; init; }
}
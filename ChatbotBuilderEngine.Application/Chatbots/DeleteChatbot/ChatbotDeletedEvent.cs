using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Chatbots.DeleteChatbot;

public sealed record ChatbotDeletedEvent(
    ChatbotId ChatbotId,
    UserId OwnerId
) : IEvent;
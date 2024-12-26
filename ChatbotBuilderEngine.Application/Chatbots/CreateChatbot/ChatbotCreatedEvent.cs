using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;

namespace ChatbotBuilderEngine.Application.Chatbots.CreateChatbot;

public sealed record ChatbotCreatedEvent(ChatbotId Id) : IEvent;
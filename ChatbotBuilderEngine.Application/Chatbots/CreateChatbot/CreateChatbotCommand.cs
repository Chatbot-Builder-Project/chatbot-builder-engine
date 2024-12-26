using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;

namespace ChatbotBuilderEngine.Application.Chatbots.CreateChatbot;

public sealed class CreateChatbotCommand : ICommand<CreateResponse<ChatbotId>>
{
    public required WorkflowId WorkflowId { get; init; }
    public required UserId OwnerId { get; init; }
    public required bool IsPublic { get; init; }
}
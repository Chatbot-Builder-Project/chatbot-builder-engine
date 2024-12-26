using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;
using Version = ChatbotBuilderEngine.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderEngine.Application.Chatbots.GetChatbot;

public sealed record GetChatbotResponse(
    ChatbotId Id,
    UserId OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    GetChatbotResponseAdminDetails? AdminDetails);

public sealed record GetChatbotResponseAdminDetails(
    Version Version,
    WorkflowId WorkflowId,
    bool IsPublic,
    bool IsLatest);
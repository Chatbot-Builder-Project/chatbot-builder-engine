using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;

namespace ChatbotBuilderEngine.Application.Chatbots.ListChatbots;

public sealed class ListChatbotsQuery : IQuery<ListChatbotsResponse>
{
    public required PageParams PageParams { get; init; }
    public required UserId UserId { get; init; }
    public string? Search { get; init; }
    public bool IncludeOnlyPersonal { get; init; }
    public bool IncludeOnlyLatest { get; init; } = true;
    public WorkflowId? WorkflowId { get; init; }
}
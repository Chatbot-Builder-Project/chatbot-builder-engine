using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Application.Workflows.ListWorkflows;

public sealed class ListWorkflowsQuery : IQuery<ListWorkflowsResponse>
{
    public required PageParams PageParams { get; init; }
    public required UserId OwnerId { get; init; }
    public string? Search { get; init; }
}
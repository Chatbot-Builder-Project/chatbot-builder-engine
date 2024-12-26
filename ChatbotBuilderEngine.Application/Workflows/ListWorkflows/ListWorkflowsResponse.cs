using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;

namespace ChatbotBuilderEngine.Application.Workflows.ListWorkflows;

public sealed record ListWorkflowsResponse(PageResponse<ListWorkflowsResponseItem> Page);

public sealed record ListWorkflowsResponseItem(
    WorkflowId Id,
    UserId OwnerId,
    string Name,
    string Description,
    DateTime CreatedAt,
    DateTime UpdatedAt);
using ChatbotBuilderEngine.Application.Graphs;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;

namespace ChatbotBuilderEngine.Application.Workflows.GetWorkflow;

public sealed record GetWorkflowResponse(
    WorkflowId Id,
    UserId OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    GraphDto Graph);
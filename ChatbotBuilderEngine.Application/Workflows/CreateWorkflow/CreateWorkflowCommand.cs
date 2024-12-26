using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Application.Graphs;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;

namespace ChatbotBuilderEngine.Application.Workflows.CreateWorkflow;

public sealed class CreateWorkflowCommand : ICommand<CreateResponse<WorkflowId>>
{
    public required UserId OwnerId { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required GraphDto Graph { get; init; }
}
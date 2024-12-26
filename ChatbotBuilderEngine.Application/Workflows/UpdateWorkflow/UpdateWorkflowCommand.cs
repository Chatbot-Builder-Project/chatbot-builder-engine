using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Graphs;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;

namespace ChatbotBuilderEngine.Application.Workflows.UpdateWorkflow;

public sealed class UpdateWorkflowCommand : ICommand
{
    public required WorkflowId Id { get; init; }
    public required UserId OwnerId { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required GraphDto Graph { get; init; }
}
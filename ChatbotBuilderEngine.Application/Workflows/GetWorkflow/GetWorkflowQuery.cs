using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;

namespace ChatbotBuilderEngine.Application.Workflows.GetWorkflow;

public sealed class GetWorkflowQuery : IQuery<GetWorkflowResponse>
{
    public required WorkflowId Id { get; init; }
    public required UserId OwnerId { get; init; }
}
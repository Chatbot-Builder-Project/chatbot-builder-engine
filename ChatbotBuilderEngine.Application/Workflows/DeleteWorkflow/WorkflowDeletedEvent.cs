using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;

namespace ChatbotBuilderEngine.Application.Workflows.DeleteWorkflow;

public sealed record WorkflowDeletedEvent(
    WorkflowId WorkflowId,
    UserId OwnerId
) : IEvent;
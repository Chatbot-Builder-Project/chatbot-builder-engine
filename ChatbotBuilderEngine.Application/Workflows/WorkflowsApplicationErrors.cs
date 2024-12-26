using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Application.Workflows;

public static class WorkflowsApplicationErrors
{
    public static readonly Error WorkflowNotFound = Error.ResourceConflict(
        "Workflows.WorkflowNotFound",
        "Workflow not found.");
}
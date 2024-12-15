using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Workflows;

public sealed class WorkflowId : EntityId<WorkflowId>
{
    public WorkflowId(Guid value) : base(value)
    {
    }
}
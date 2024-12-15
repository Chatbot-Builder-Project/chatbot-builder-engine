using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Domain.Workflows;

public sealed class Workflow : AggregateRoot<WorkflowId>
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public UserId OwnerId { get; } = null!;
    public GraphId GraphId { get; } = null!;

    private Workflow(
        WorkflowId id,
        string name,
        string description,
        UserId ownerId,
        GraphId graphId)
        : base(id)
    {
        Name = name;
        Description = description;
        OwnerId = ownerId;
        GraphId = graphId;
    }

    /// <inheritdoc/>
    private Workflow()
    {
    }

    public static Workflow Create(
        WorkflowId id,
        string name,
        string description,
        UserId ownerId,
        GraphId graphId)
    {
        return new Workflow(id, name, description, ownerId, graphId);
    }
}
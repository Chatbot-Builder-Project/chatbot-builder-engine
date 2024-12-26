using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs;
using ChatbotBuilderEngine.Domain.Users;

namespace ChatbotBuilderEngine.Domain.Workflows;

public sealed class Workflow : AggregateRoot<WorkflowId>
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public UserId OwnerId { get; } = null!;
    public Graph Graph { get; private set; } = null!;

    private Workflow(
        WorkflowId id,
        string name,
        string description,
        UserId ownerId,
        Graph graph)
        : base(id)
    {
        Name = name;
        Description = description;
        OwnerId = ownerId;
        Graph = graph;
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
        Graph graph)
    {
        return new Workflow(id, name, description, ownerId, graph);
    }

    public void Update(
        string name,
        string description,
        Graph graph)
    {
        Name = name;
        Description = description;
        Graph = graph;
    }
}
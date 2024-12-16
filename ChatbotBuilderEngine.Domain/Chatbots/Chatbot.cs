using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs;
using ChatbotBuilderEngine.Domain.Workflows;
using Version = ChatbotBuilderEngine.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderEngine.Domain.Chatbots;

public sealed class Chatbot : AggregateRoot<ChatbotId>
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public WorkflowId WorkflowId { get; private set; } = null!;
    public Version Version { get; } = null!;
    public Graph Graph { get; } = null!;
    public bool IsPublic { get; private set; }

    private Chatbot(
        ChatbotId id,
        string name,
        string description,
        WorkflowId workflowId,
        Version version,
        Graph graph,
        bool isPublic)
        : base(id)
    {
        Name = name;
        Description = description;
        WorkflowId = workflowId;
        Version = version;
        Graph = graph;
        IsPublic = isPublic;
    }

    /// <inheritdoc/>
    private Chatbot()
    {
    }

    public static Chatbot Create(
        ChatbotId id,
        string name,
        string description,
        WorkflowId workflowId,
        Version version,
        Graph graph,
        bool isPublic)
    {
        return new Chatbot(id, name, description, workflowId, version, graph, isPublic);
    }
}
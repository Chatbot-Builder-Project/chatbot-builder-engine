using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract;

public interface IGraphTraversalService
{
    Graph Graph { get; set; }
    Task InitializeGraphAsync();
    NodeId GetSuccessor(NodeId nodeId);
    Task<NodeId> TraverseAsync(NodeId interactionNodeId);
}
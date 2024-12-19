using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderEngine.Domain.Graphs;

public sealed class GraphTraversalService : IGraphTraversalService
{
    private Graph? _graph;

    public Graph Graph
    {
        get => _graph ?? throw new DomainException(GraphsDomainErrors.GraphTraversal.GraphNotSet);
        set
        {
            _graph = value;
            foreach (var flowLink in _graph.FlowLinks)
            {
                _nodeOutputFlowLinks.TryAdd(flowLink.InputNodeId, []);
                _nodeOutputFlowLinks[flowLink.InputNodeId].Add(flowLink.Id);
            }
        }
    }

    /// <remarks>
    /// For O(1) successor lookup
    /// </remarks>
    private readonly Dictionary<NodeId, HashSet<FlowLinkId>> _nodeOutputFlowLinks = [];

    /// <summary>
    /// Runs the lifecycle steps of the node, which includes:
    /// <list type="number">
    /// <item>Running the node's logic </item>
    /// <item>Publishing the node's outputs </item>
    /// </list>
    /// </summary>
    /// <param name="node"></param>
    private static async Task ActivateNodeAsync(Node node)
    {
        await node.RunAsync();

        if (node is IOutputNode outputNode)
        {
            outputNode.PublishOutputs();
        }
    }

    public async Task InitializeGraphAsync()
    {
        foreach (var setupNode in Graph.Nodes.Where(n => n is ISetupNode))
        {
            await ActivateNodeAsync(setupNode);
        }
    }

    public NodeId GetSuccessor(NodeId nodeId)
    {
        if (!Graph.NodesMap.TryGetValue(nodeId, out var node))
        {
            throw new DomainException(GraphsDomainErrors.Graph.NodeDoesNotExist);
        }

        if (node is ISwitchNode switchNode)
        {
            var flowLinkId = switchNode.GetSelectedFlowLinkId();
            return Graph.FlowLinksMap[flowLinkId].OutputNodeId;
        }

        if (!_nodeOutputFlowLinks.TryGetValue(nodeId, out var flowLinkIds))
        {
            throw new DomainException(GraphsDomainErrors.Graph.NodeDoesNotExist);
        }

        if (flowLinkIds.Count > 1)
        {
            throw new DomainException(GraphsDomainErrors.Graph.NonSwitchNodeHasMultipleOutputFlowLinks);
        }

        return Graph.FlowLinksMap[flowLinkIds.First()].OutputNodeId;
    }

    /// <summary>
    /// Traverses the graph starting from the interaction node until it hits another interaction node.
    /// At each node, it activates the node and then moves to its successor.
    /// </summary>
    /// <returns>The ID of the next interaction node</returns>
    public async Task<NodeId> TraverseAsync(NodeId interactionNodeId)
    {
        if (!Graph.NodesMap.TryGetValue(interactionNodeId, out var interactionNode)
            || interactionNode is not InteractionNode)
        {
            throw new DomainException(GraphsDomainErrors.Graph.InteractionNodeNotFound);
        }

        var currentNodeId = GetSuccessor(interactionNodeId);
        do
        {
            await ActivateNodeAsync(interactionNode);
            currentNodeId = GetSuccessor(currentNodeId);
        } while (Graph.NodesMap[currentNodeId] is not InteractionNode);

        return currentNodeId;
    }
}
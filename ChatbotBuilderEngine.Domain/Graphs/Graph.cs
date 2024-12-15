using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Links;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes.Interaction;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using Enum = ChatbotBuilderEngine.Domain.Graphs.Entities.Enum;

namespace ChatbotBuilderEngine.Domain.Graphs;

/// <summary>
/// To create the graph, the following steps will be executed in order (internally):
/// <list type="number">
/// <item>Add all enums</item>
/// <item>Add all input and output ports</item>
/// <item>Add all nodes</item>
/// <item>Set the start node id</item>
/// <item>Add all data and flow links</item>
/// </list>
/// </summary>
/// <remarks>
/// Corresponds (approximately) to WorkflowComponents in upper layers.
/// </remarks>
public abstract class Graph : Entity<GraphId>
{
    private readonly Dictionary<EnumId, Enum> _enums = [];
    private readonly Dictionary<InputPortId, Port<InputPortId>> _inputPorts = [];
    private readonly Dictionary<OutputPortId, Port<OutputPortId>> _outputPorts = [];
    private readonly Dictionary<NodeId, Node> _nodes = [];
    private readonly Dictionary<FlowLinkId, FlowLink> _flowLinks = [];
    private readonly Dictionary<DataLinkId, DataLink> _dataLinks = [];

    public IReadOnlyDictionary<EnumId, Enum> Enums => _enums;
    public IReadOnlyDictionary<InputPortId, Port<InputPortId>> InputPorts => _inputPorts;
    public IReadOnlyDictionary<OutputPortId, Port<OutputPortId>> OutputPorts => _outputPorts;
    public IReadOnlyDictionary<NodeId, Node> Nodes => _nodes;
    public NodeId StartNodeId { get; private set; } = null!;
    public IReadOnlyDictionary<FlowLinkId, FlowLink> FlowLinks => _flowLinks;
    public IReadOnlyDictionary<DataLinkId, DataLink> DataLinks => _dataLinks;

    protected Graph(
        GraphId id,
        DateTime createdAt,
        DateTime updatedAt)
        : base(id, createdAt, updatedAt)
    {
    }

    /// <inheritdoc/>
    protected Graph()
    {
    }

    protected void Initialize(
        IReadOnlyList<Enum> enums,
        IReadOnlyList<Port<InputPortId>> inputPorts,
        IReadOnlyList<Port<OutputPortId>> outputPorts,
        IReadOnlyList<Node> nodes,
        NodeId startNodeId,
        IReadOnlyList<DataLink> dataLinks,
        IReadOnlyList<FlowLink> flowLinks)
    {
        foreach (var @enum in enums)
        {
            AddEnum(@enum);
        }

        foreach (var inputPort in inputPorts)
        {
            AddInputPort(inputPort);
        }

        foreach (var outputPort in outputPorts)
        {
            AddOutputPort(outputPort);
        }

        foreach (var node in nodes)
        {
            AddNode(node);
        }

        SetStartNodeId(startNodeId);

        foreach (var dataLink in dataLinks)
        {
            AddDataLink(dataLink);
        }

        // Precomputation for O(1) FlowLinkId lookup
        var switchNodeFlowLinks = nodes
            .OfType<ISwitchNode>()
            .ToDictionary(
                switchNode => (Node)switchNode,
                switchNode => switchNode.GetFlowLinkIds().ToHashSet());

        foreach (var flowLink in flowLinks)
        {
            AddFlowLink(flowLink, switchNodeFlowLinks);
        }
    }

    private void AddEnum(Enum @enum)
    {
        if (!_enums.TryAdd(@enum.Id, @enum))
        {
            throw new DomainException(GraphsDomainErrors.Graph.EnumAlreadyExists);
        }
    }

    private void AddInputPort(Port<InputPortId> port)
    {
        if (!port.GetType().IsAssignableTo(typeof(InputPort<>)))
        {
            throw new DomainException(GraphsDomainErrors.InputPort.IsNotInputPort);
        }

        if (!_inputPorts.TryAdd(port.Id, port))
        {
            throw new DomainException(GraphsDomainErrors.Graph.InputPortAlreadyExists);
        }
    }

    private void AddOutputPort(Port<OutputPortId> port)
    {
        if (!port.GetType().IsAssignableTo(typeof(OutputPort<>)))
        {
            throw new DomainException(GraphsDomainErrors.OutputPort.IsNotOutputPort);
        }

        if (!_outputPorts.TryAdd(port.Id, port))
        {
            throw new DomainException(GraphsDomainErrors.Graph.OutputPortAlreadyExists);
        }
    }

    private void AddNode(Node node)
    {
        switch (node)
        {
            case IInputNode inputNode when
                inputNode.GetInputPortIds().Any(inputPortId => !_inputPorts.ContainsKey(inputPortId)):
                throw new DomainException(GraphsDomainErrors.Graph.InputPortDoesNotExist);

            case IOutputNode outputNode when
                outputNode.GetOutputPortIds().Any(outputPortId => !_outputPorts.ContainsKey(outputPortId)):
                throw new DomainException(GraphsDomainErrors.Graph.OutputPortDoesNotExist);

            case IEnumNode enumNode when
                enumNode.GetEnumIds().Any(enumId => !_enums.ContainsKey(enumId)):
                throw new DomainException(GraphsDomainErrors.Graph.EnumDoesNotExist);
        }

        if (!_nodes.TryAdd(node.Id, node))
        {
            throw new DomainException(GraphsDomainErrors.Graph.NodeAlreadyExists);
        }
    }

    private void SetStartNodeId(NodeId startNodeId)
    {
        if (!_nodes.TryGetValue(startNodeId, out var node))
        {
            throw new DomainException(GraphsDomainErrors.Graph.NodeDoesNotExist);
        }

        if (node is not InteractionNode)
        {
            throw new DomainException(GraphsDomainErrors.Graph.StartNodeIsNotInteractionNode);
        }

        StartNodeId = startNodeId;
    }

    private void AddDataLink(DataLink link)
    {
        if (!_inputPorts.TryGetValue(link.InputPortId, out var inputPort))
        {
            throw new DomainException(GraphsDomainErrors.Graph.InputPortDoesNotExist);
        }

        if (!_outputPorts.TryGetValue(link.OutputPortId, out var outputPort))
        {
            throw new DomainException(GraphsDomainErrors.Graph.OutputPortDoesNotExist);
        }

        var inputDataType = inputPort.GetType().GetGenericArguments()[0];
        var outputDataType = outputPort.GetType().GetGenericArguments()[0];
        if (inputDataType != outputDataType)
        {
            throw new DomainException(GraphsDomainErrors.Graph.DataLinkTypeMismatch);
        }

        if (!_dataLinks.TryAdd(link.Id, link))
        {
            throw new DomainException(GraphsDomainErrors.Graph.DataLinkAlreadyExists);
        }

        var outputPortType = outputPort.GetType();
        var subscribeMethod = outputPortType.GetMethod("Subscribe") ??
                              throw new InvalidOperationException(
                                  $"Subscribe method not found on {outputPortType.Name}");

        subscribeMethod.Invoke(outputPort, [inputPort]);
    }

    private void AddFlowLink(FlowLink link, IReadOnlyDictionary<Node, HashSet<FlowLinkId>> switchNodeFlowLinks)
    {
        if (!_nodes.TryGetValue(link.InputNodeId, out var inputNode))
        {
            throw new DomainException(GraphsDomainErrors.Graph.NodeDoesNotExist);
        }

        if (!_nodes.TryGetValue(link.OutputNodeId, out var outputNode))
        {
            throw new DomainException(GraphsDomainErrors.Graph.NodeDoesNotExist);
        }

        if (inputNode is ISetupNode || outputNode is ISetupNode)
        {
            throw new DomainException(GraphsDomainErrors.Graph.FlowLinkCannotBeUsedForSetupNode);
        }

        if (inputNode is ISwitchNode &&
            !switchNodeFlowLinks[inputNode].Contains(link.Id))
        {
            throw new DomainException(GraphsDomainErrors.Graph.SwitchNodeDoesNotContainFlowLink);
        }

        if (!_flowLinks.TryAdd(link.Id, link))
        {
            throw new DomainException(GraphsDomainErrors.Graph.FlowLinkAlreadyExists);
        }
    }
}
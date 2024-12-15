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
/// To create the graph, the following steps and validations will be executed in order:
/// <list type="number">
/// <item>Add all enums</item>
/// <item>Add all input and output ports</item>
/// <item>Add all nodes, ensure that all their ports and enums exist</item>
/// <item>Ensure that no extra ports exist, extra enums are allowed</item>
/// <item>Set the start node id, ensure that it's an interaction node and that it exists</item>
/// <item>Add all data links, ensure that all their ports exist</item>
/// <item>Ensure that no InputPort is without at least one DataLink.
/// (In the future it should also ensure that at no graph path can an input port be uninitialized,
/// possible by enforcing a default value for each InputPort)</item>
/// <item>Add all flow links, ensure that all their nodes exist and that they are not setup nodes.
/// And if the input node is a SwitchNode ensure that its ID is already bound to the node.
/// Extra nodes are allowed.</item>
/// <item>Ensure that no SwitchNode contains extra flow link IDs</item>
/// </list>
/// </summary>
/// <remarks>
/// Corresponds to WorkflowComponents in upper layers.
/// </remarks>
public sealed class Graph : AggregateRoot<GraphId>
{
    private readonly HashSet<Enum> _enums = [];
    private readonly HashSet<Port<InputPortId>> _inputPorts = [];
    private readonly HashSet<Port<OutputPortId>> _outputPorts = [];
    private readonly HashSet<Node> _nodes = [];
    private readonly HashSet<FlowLink> _flowLinks = [];
    private readonly HashSet<DataLink> _dataLinks = [];

    public NodeId StartNodeId { get; private set; } = null!;
    public IReadOnlySet<Enum> Enums => _enums;
    public IReadOnlySet<Port<InputPortId>> InputPorts => _inputPorts;
    public IReadOnlySet<Port<OutputPortId>> OutputPorts => _outputPorts;
    public IReadOnlySet<Node> Nodes => _nodes;
    public IReadOnlySet<FlowLink> FlowLinks => _flowLinks;
    public IReadOnlySet<DataLink> DataLinks => _dataLinks;

    private readonly Lazy<Dictionary<EnumId, Enum>> _enumsMapLazy;
    private readonly Lazy<Dictionary<InputPortId, Port<InputPortId>>> _inputPortsMapLazy;
    private readonly Lazy<Dictionary<OutputPortId, Port<OutputPortId>>> _outputPortsMapLazy;
    private readonly Lazy<Dictionary<NodeId, Node>> _nodesMapLazy;
    private readonly Lazy<Dictionary<FlowLinkId, FlowLink>> _flowLinksMapLazy;
    private readonly Lazy<Dictionary<DataLinkId, DataLink>> _dataLinksMapLazy;

    public IReadOnlyDictionary<EnumId, Enum> EnumsMap => _enumsMapLazy.Value;
    public IReadOnlyDictionary<InputPortId, Port<InputPortId>> InputPortsMap => _inputPortsMapLazy.Value;
    public IReadOnlyDictionary<OutputPortId, Port<OutputPortId>> OutputPortsMap => _outputPortsMapLazy.Value;
    public IReadOnlyDictionary<NodeId, Node> NodesMap => _nodesMapLazy.Value;
    public IReadOnlyDictionary<FlowLinkId, FlowLink> FlowLinksMap => _flowLinksMapLazy.Value;
    public IReadOnlyDictionary<DataLinkId, DataLink> DataLinksMap => _dataLinksMapLazy.Value;

    private Graph(
        GraphId id,
        DateTime createdAt,
        DateTime updatedAt)
        : base(id, createdAt, updatedAt)
    {
        _enumsMapLazy = new(() => Enums.ToDictionary(@enum => @enum.Id, @enum => @enum));
        _inputPortsMapLazy = new(() => InputPorts.ToDictionary(port => port.Id, port => port));
        _outputPortsMapLazy = new(() => OutputPorts.ToDictionary(port => port.Id, port => port));
        _nodesMapLazy = new(() => Nodes.ToDictionary(node => node.Id, node => node));
        _flowLinksMapLazy = new(() => FlowLinks.ToDictionary(link => link.Id, link => link));
        _dataLinksMapLazy = new(() => DataLinks.ToDictionary(link => link.Id, link => link));
    }

    /// <inheritdoc/>
    private Graph() : this(default!, default!, default!)
    {
    }

    public static Graph Create(
        GraphId id,
        DateTime createdAt,
        DateTime updatedAt,
        IReadOnlyList<Enum> enums,
        IReadOnlyList<Port<InputPortId>> inputPorts,
        IReadOnlyList<Port<OutputPortId>> outputPorts,
        IReadOnlyList<Node> nodes,
        NodeId startNodeId,
        IReadOnlyList<DataLink> dataLinks,
        IReadOnlyList<FlowLink> flowLinks)
    {
        var graph = new Graph(id, createdAt, updatedAt);

        foreach (var @enum in enums)
        {
            graph.AddEnum(@enum);
        }

        foreach (var inputPort in inputPorts)
        {
            graph.AddInputPort(inputPort);
        }

        foreach (var outputPort in outputPorts)
        {
            graph.AddOutputPort(outputPort);
        }

        foreach (var node in nodes)
        {
            graph.AddNode(node);
        }

        graph.EnsureNoExtraPorts();

        graph.SetStartNodeId(startNodeId);

        foreach (var dataLink in dataLinks)
        {
            graph.AddDataLink(dataLink);
        }

        graph.EnsureNoUnconnectedInputPorts();

        // Precomputation for O(1) FlowLinkId lookup
        var switchNodeFlowLinks = nodes
            .OfType<ISwitchNode>()
            .ToDictionary(
                switchNode => (Node)switchNode,
                switchNode => switchNode.GetFlowLinkIds().ToHashSet());

        foreach (var flowLink in flowLinks)
        {
            graph.AddFlowLink(flowLink, switchNodeFlowLinks);
        }

        graph.EnsureNoUnconnectedFlowLinkInSwitchNodes(switchNodeFlowLinks);

        return graph;
    }

    private void AddEnum(Enum @enum)
    {
        if (!_enums.Add(@enum))
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

        if (!_inputPorts.Add(port))
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

        if (!_outputPorts.Add(port))
        {
            throw new DomainException(GraphsDomainErrors.Graph.OutputPortAlreadyExists);
        }
    }

    /// <remarks>
    /// This method assumes all enums, input ports and output ports have been added to the graph.
    /// </remarks>
    private void AddNode(Node node)
    {
        switch (node)
        {
            case IInputNode inputNode when
                inputNode.GetInputPortIds().Any(inputPortId => !InputPortsMap.ContainsKey(inputPortId)):
                throw new DomainException(GraphsDomainErrors.Graph.InputPortDoesNotExist);

            case IOutputNode outputNode when
                outputNode.GetOutputPortIds().Any(outputPortId => !OutputPortsMap.ContainsKey(outputPortId)):
                throw new DomainException(GraphsDomainErrors.Graph.OutputPortDoesNotExist);

            case IEnumNode enumNode when
                enumNode.GetEnumIds().Any(enumId => !EnumsMap.ContainsKey(enumId)):
                throw new DomainException(GraphsDomainErrors.Graph.EnumDoesNotExist);
        }

        if (!_nodes.Add(node))
        {
            throw new DomainException(GraphsDomainErrors.Graph.NodeAlreadyExists);
        }
    }

    private void EnsureNoExtraPorts()
    {
        var nodeInputPortIds = Nodes
            .OfType<IInputNode>()
            .SelectMany(node => node.GetInputPortIds())
            .ToHashSet();

        var nodeOutputPortIds = Nodes
            .OfType<IOutputNode>()
            .SelectMany(node => node.GetOutputPortIds())
            .ToHashSet();

        if (InputPorts.Any(port => !nodeInputPortIds.Contains(port.Id)))
        {
            throw new DomainException(GraphsDomainErrors.Graph.ExtraInputPorts);
        }

        if (OutputPorts.Any(port => !nodeOutputPortIds.Contains(port.Id)))
        {
            throw new DomainException(GraphsDomainErrors.Graph.ExtraOutputPorts);
        }
    }

    /// <remarks>
    /// This method assumes all nodes have been added to the graph.
    /// </remarks>
    private void SetStartNodeId(NodeId startNodeId)
    {
        if (!NodesMap.TryGetValue(startNodeId, out var node))
        {
            throw new DomainException(GraphsDomainErrors.Graph.NodeDoesNotExist);
        }

        if (node is not InteractionNode)
        {
            throw new DomainException(GraphsDomainErrors.Graph.StartNodeIsNotInteractionNode);
        }

        StartNodeId = startNodeId;
    }

    /// <remarks>
    /// This method assumes all input ports and output ports have been added to the graph.
    /// </remarks>
    private void AddDataLink(DataLink link)
    {
        if (!InputPortsMap.TryGetValue(link.InputPortId, out var inputPort))
        {
            throw new DomainException(GraphsDomainErrors.Graph.InputPortDoesNotExist);
        }

        if (!OutputPortsMap.TryGetValue(link.OutputPortId, out var outputPort))
        {
            throw new DomainException(GraphsDomainErrors.Graph.OutputPortDoesNotExist);
        }

        var inputDataType = inputPort.GetType().GetGenericArguments()[0];
        var outputDataType = outputPort.GetType().GetGenericArguments()[0];
        if (inputDataType != outputDataType)
        {
            throw new DomainException(GraphsDomainErrors.Graph.DataLinkTypeMismatch);
        }

        if (!_dataLinks.Add(link))
        {
            throw new DomainException(GraphsDomainErrors.Graph.DataLinkAlreadyExists);
        }

        var outputPortType = outputPort.GetType();
        var subscribeMethod = outputPortType.GetMethod("Subscribe") ??
                              throw new InvalidOperationException(
                                  $"Subscribe method not found on {outputPortType.Name}");

        subscribeMethod.Invoke(outputPort, [inputPort]);
    }

    private void EnsureNoUnconnectedInputPorts()
    {
        var connectedInputPortIds = DataLinks
            .Select(link => link.InputPortId)
            .ToHashSet();

        if (InputPorts.Any(port => !connectedInputPortIds.Contains(port.Id)))
        {
            throw new DomainException(GraphsDomainErrors.Graph.UnconnectedInputPorts);
        }
    }

    /// <remarks>
    /// This method assumes all nodes have been added to the graph.
    /// </remarks>
    private void AddFlowLink(FlowLink link, IReadOnlyDictionary<Node, HashSet<FlowLinkId>> switchNodeFlowLinks)
    {
        if (!NodesMap.TryGetValue(link.InputNodeId, out var inputNode))
        {
            throw new DomainException(GraphsDomainErrors.Graph.NodeDoesNotExist);
        }

        if (!NodesMap.TryGetValue(link.OutputNodeId, out var outputNode))
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

        if (!_flowLinks.Add(link))
        {
            throw new DomainException(GraphsDomainErrors.Graph.FlowLinkAlreadyExists);
        }
    }

    private void EnsureNoUnconnectedFlowLinkInSwitchNodes(
        IReadOnlyDictionary<Node, HashSet<FlowLinkId>> switchNodeFlowLinks)
    {
        var flowLinkIds = FlowLinks.Select(link => link.Id).ToHashSet();

        if (switchNodeFlowLinks.Values.Any(set => set.Any(id => !flowLinkIds.Contains(id))))
        {
            throw new DomainException(GraphsDomainErrors.Graph.SwitchNodeContainsExtraFlowLinkIds);
        }
    }
}
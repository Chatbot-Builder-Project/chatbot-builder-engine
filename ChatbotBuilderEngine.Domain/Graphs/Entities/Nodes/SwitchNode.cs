using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;

public sealed class SwitchNode : Node,
    IInputNode, IEnumNode, IActiveNode, IMultiFlowNode
{
    public InputPort<OptionData> InputPort { get; } = null!;
    public Enum Enum { get; } = null!;
    public Dictionary<OptionData, FlowLinkId> Bindings { get; } = null!;

    private OptionData? _selectedOption;
    private readonly Dictionary<FlowLinkId, IFlowNode> _successors = [];

    private SwitchNode(
        NodeId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        InputPort<OptionData> inputPort,
        Enum @enum,
        Dictionary<OptionData, FlowLinkId> bindings)
        : base(id, createdAt, updatedAt, info, visual)
    {
        InputPort = inputPort;
        Enum = @enum;
        Bindings = bindings;
    }

    /// <inheritdoc/>
    private SwitchNode()
    {
    }

    public static SwitchNode Create(
        NodeId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        InputPort<OptionData> inputPort,
        Enum @enum,
        Dictionary<OptionData, FlowLinkId> bindings)
    {
        if (@enum.Options.Any(enumOption => !bindings.ContainsKey(enumOption)))
        {
            throw new DomainException(GraphsDomainErrors.SwitchNode.OptionNotBound);
        }

        if (bindings.Count != @enum.Options.Count)
        {
            throw new DomainException(GraphsDomainErrors.SwitchNode.InvalidBindingsCount);
        }

        inputPort.EnsureNodeIdIs(id);

        return new SwitchNode(id, createdAt, updatedAt, info, visual, inputPort, @enum, bindings);
    }

    public IEnumerable<InputPortId> GetInputPortIds()
    {
        yield return InputPort.Id;
    }


    public Task ActivateAsync()
    {
        _selectedOption = InputPort.GetData();
        return Task.CompletedTask;
    }

    public IFlowNode GetSuccessor()
    {
        if (_selectedOption is null)
        {
            throw new DomainException(GraphsDomainErrors.SwitchNode.HasNotBeenActivated);
        }

        if (!Bindings.TryGetValue(_selectedOption, out var flowLinkId))
        {
            throw new DomainException(GraphsDomainErrors.SwitchNode.OptionNotBound);
        }

        if (!_successors.TryGetValue(flowLinkId, out var successor))
        {
            throw new DomainException(GraphsDomainErrors.SwitchNode.FlowLinkNotBound);
        }

        return successor;
    }

    public void Bind(FlowLinkId flowLinkId, IFlowNode node)
    {
        if (!_successors.TryAdd(flowLinkId, node))
        {
            throw new DomainException(GraphsDomainErrors.SwitchNode.FlowLinkAlreadyBound);
        }
    }

    public IEnumerable<EnumId> GetEnumIds()
    {
        yield return Enum.Id;
    }
}
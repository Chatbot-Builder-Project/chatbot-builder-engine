using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;

public sealed class SwitchNode : Node,
    IInputNode, IEnumNode, ISwitchNode
{
    public InputPort<OptionData> InputPort { get; } = null!;
    public Enum Enum { get; } = null!;
    public Dictionary<OptionData, FlowLinkId> Bindings { get; } = null!;
    public OptionData? SelectedOption { get; private set; }

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
        @enum.EnsureValidBindings(bindings);
        inputPort.EnsureNodeIdIs(id);

        return new SwitchNode(id, createdAt, updatedAt, info, visual, inputPort, @enum, bindings);
    }

    public override Task RunAsync()
    {
        SelectedOption = InputPort.GetData();
        return Task.CompletedTask;
    }

    public IEnumerable<InputPortId> GetInputPortIds()
    {
        yield return InputPort.Id;
    }

    public IEnumerable<EnumId> GetEnumIds()
    {
        yield return Enum.Id;
    }

    public IEnumerable<FlowLinkId> GetFlowLinkIds()
    {
        return Bindings.Values;
    }

    public FlowLinkId GetFlowLinkId(OptionData option)
    {
        if (SelectedOption is null)
        {
            throw new DomainException(GraphsDomainErrors.SwitchNode.HasNotBeenActivated);
        }

        if (!Bindings.TryGetValue(SelectedOption, out var flowLinkId))
        {
            throw new DomainException(GraphsDomainErrors.SwitchNode.OptionNotBound);
        }

        return flowLinkId;
    }
}
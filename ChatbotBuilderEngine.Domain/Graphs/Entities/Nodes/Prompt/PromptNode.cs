using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes.Prompt;

public sealed class PromptNode : Node,
    IInputNode, IActiveNode, IOutputNode, ISingleFlowNode
{
    private readonly IReadOnlyList<InputPort<TextData>> _inputPorts = [];
    private string _injectedTemplate = string.Empty;
    private IFlowNode? _successor;

    public PromptTemplate Template { get; } = null!;
    public OutputPort<TextData> OutputPort { get; } = null!;

    private PromptNode(
        NodeId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        PromptTemplate template,
        OutputPort<TextData> outputPort,
        IReadOnlyList<InputPort<TextData>> inputPorts)
        : base(id, createdAt, updatedAt, info, visual)
    {
        Template = template;
        OutputPort = outputPort;
        _inputPorts = inputPorts;
    }

    /// <inheritdoc/>
    private PromptNode()
    {
    }

    public static PromptNode Create(
        NodeId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        PromptTemplate template,
        OutputPort<TextData> outputPort,
        IReadOnlyList<InputPort<TextData>> inputPorts)
    {
        // Make sure it doesn't throw an exception
        var values = inputPorts.ToDictionary(
            ip => ip.Info.Identifier.ToString(),
            _ => string.Empty);
        template.InjectValues(values);

        outputPort.EnsureNodeIdIs(id);
        foreach (var inputPort in inputPorts)
        {
            inputPort.EnsureNodeIdIs(id);
        }

        return new PromptNode(id, createdAt, updatedAt, info, visual, template, outputPort, inputPorts);
    }

    public IEnumerable<InputPortId> GetInputPortIds()
    {
        return _inputPorts.Select(ip => ip.Id);
    }

    public Task ActivateAsync()
    {
        var values = _inputPorts.ToDictionary(
            ip => ip.Info.Identifier.ToString(),
            ip => ip.GetData().Text);

        _injectedTemplate = Template.InjectValues(values);
        return Task.CompletedTask;
    }

    public IEnumerable<OutputPortId> GetOutputPortIds()
    {
        yield return OutputPort.Id;
    }

    public void PublishOutputs()
    {
        OutputPort.Publish(TextData.Create(_injectedTemplate));
    }

    public IFlowNode GetSuccessor()
    {
        return _successor ??
               throw new DomainException(GraphsDomainErrors.PromptNode.SuccessorNotSet);
    }

    public void SetSuccessor(IFlowNode successor)
    {
        _successor = successor;
    }
}
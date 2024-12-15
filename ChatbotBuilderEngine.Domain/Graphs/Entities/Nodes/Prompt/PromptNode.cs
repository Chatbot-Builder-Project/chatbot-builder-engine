using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes.Prompt;

public sealed class PromptNode : Node,
    IInputNode, IOutputNode
{
    public PromptTemplate Template { get; } = null!;
    public OutputPort<TextData> OutputPort { get; } = null!;
    public IReadOnlySet<InputPort<TextData>> InputPorts { get; } = null!;
    public string? InjectedTemplate { get; private set; }

    private PromptNode(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        PromptTemplate template,
        OutputPort<TextData> outputPort,
        IReadOnlySet<InputPort<TextData>> inputPorts)
        : base(id, info, visual)
    {
        Template = template;
        OutputPort = outputPort;
        InputPorts = inputPorts;
    }

    /// <inheritdoc/>
    private PromptNode()
    {
    }

    public static PromptNode Create(
        NodeId id,
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

        var inputPortsSet = new HashSet<InputPort<TextData>>();
        foreach (var inputPort in inputPorts)
        {
            if (!inputPortsSet.Add(inputPort))
            {
                throw new DomainException(GraphsDomainErrors.PromptNode.DuplicateInputPorts);
            }
        }

        return new PromptNode(id, info, visual, template, outputPort, inputPortsSet);
    }

    public override Task RunAsync()
    {
        var values = InputPorts.ToDictionary(
            ip => ip.Info.Identifier.ToString(),
            ip => ip.GetData().Text);

        InjectedTemplate = Template.InjectValues(values);
        return Task.CompletedTask;
    }

    public IEnumerable<InputPortId> GetInputPortIds()
    {
        return InputPorts.Select(ip => ip.Id);
    }

    public IEnumerable<OutputPortId> GetOutputPortIds()
    {
        yield return OutputPort.Id;
    }

    public void PublishOutputs()
    {
        if (InjectedTemplate is null)
        {
            throw new DomainException(GraphsDomainErrors.PromptNode.NodeHasNotBeenActivated);
        }

        OutputPort.Publish(TextData.Create(InjectedTemplate));
    }
}
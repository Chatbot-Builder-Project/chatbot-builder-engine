using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;

public sealed class OutputPort<TData> : Port<OutputPortId>
    where TData : Data
{
    private readonly HashSet<InputPort<TData>> _inputPorts = [];

    public IReadOnlySet<InputPort<TData>> InputPorts => _inputPorts;

    private OutputPort(
        OutputPortId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        NodeId nodeId)
        : base(id, createdAt, updatedAt, info, visual, nodeId)
    {
    }

    /// <inheritdoc/>
    private OutputPort()
    {
    }

    public static OutputPort<TData> Create(
        OutputPortId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        NodeId nodeId)
    {
        return new OutputPort<TData>(id, createdAt, updatedAt, info, visual, nodeId);
    }

    public void Subscribe(InputPort<TData> inputPort)
    {
        if (!_inputPorts.Add(inputPort))
        {
            throw new DomainException(GraphsDomainErrors.OutputPort.InputPortAlreadySubscribed);
        }
    }

    public void Publish(TData data)
    {
        foreach (var inputPort in _inputPorts)
        {
            inputPort.SetData(data);
        }
    }
}
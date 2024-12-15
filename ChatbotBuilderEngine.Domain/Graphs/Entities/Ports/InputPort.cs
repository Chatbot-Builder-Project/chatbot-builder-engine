using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;

public sealed class InputPort<TData> : Port<InputPortId>
    where TData : Data
{
    /// <remarks>
    /// Getter for EF Core.
    /// </remarks>
    public TData? Data { get; private set; }

    private InputPort(
        InputPortId id,
        InfoMeta info,
        VisualMeta visual,
        NodeId nodeId)
        : base(id, info, visual, nodeId)
    {
    }

    /// <inheritdoc/>
    private InputPort()
    {
    }

    public static InputPort<TData> Create(
        InputPortId id,
        InfoMeta info,
        VisualMeta visual,
        NodeId nodeId)
    {
        return new InputPort<TData>(id, info, visual, nodeId);
    }

    public void SetData(TData data)
    {
        Data = data;
    }

    public TData GetData()
    {
        if (Data is null)
        {
            throw new DomainException(GraphsDomainErrors.InputPort.HasNoData);
        }

        return Data;
    }
}
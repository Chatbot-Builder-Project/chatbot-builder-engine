using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Links;

public sealed class DataLink : Link<DataLinkId>
{
    public InputPortId InputPortId { get; } = null!;
    public OutputPortId OutputPortId { get; } = null!;

    private DataLink(
        DataLinkId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        InputPortId inputPortId,
        OutputPortId outputPortId)
        : base(id, createdAt, updatedAt, info, visual)
    {
        InputPortId = inputPortId;
        OutputPortId = outputPortId;
    }

    /// <inheritdoc/>
    private DataLink()
    {
    }

    public static DataLink Create(
        DataLinkId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        InputPortId inputPortId,
        OutputPortId outputPortId)
    {
        return new DataLink(id, createdAt, updatedAt, info, visual, inputPortId, outputPortId);
    }
}
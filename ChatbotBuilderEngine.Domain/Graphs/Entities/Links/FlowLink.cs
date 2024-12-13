using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Links;

public sealed class FlowLink : Link<FlowLinkId>
{
    public NodeId InputNodeId { get; } = null!;
    public NodeId OutputNodeId { get; } = null!;

    private FlowLink(
        FlowLinkId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        NodeId inputNodeId,
        NodeId outputNodeId)
        : base(id, createdAt, updatedAt, info, visual)
    {
        InputNodeId = inputNodeId;
        OutputNodeId = outputNodeId;
    }

    /// <inheritdoc/>
    private FlowLink()
    {
    }

    public static FlowLink Create(
        FlowLinkId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        NodeId inputNodeId,
        NodeId outputNodeId)
    {
        return new FlowLink(id, createdAt, updatedAt, info, visual, inputNodeId, outputNodeId);
    }
}
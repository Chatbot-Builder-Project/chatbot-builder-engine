using ChatbotBuilderEngine.Application.Graphs.Enums;
using ChatbotBuilderEngine.Application.Graphs.Links.DataLinks;
using ChatbotBuilderEngine.Application.Graphs.Links.FlowLinks;
using ChatbotBuilderEngine.Application.Graphs.Nodes;

namespace ChatbotBuilderEngine.Application.Graphs;

public sealed class GraphDto
{
    public required int StartNodeIdentifier { get; init; }
    public required IReadOnlyList<NodeDto> Nodes { get; init; }
    public required IReadOnlyList<DataLinkDto> DataLinks { get; init; }
    public required IReadOnlyList<FlowLinkDto> FlowLinks { get; init; }
    public required IReadOnlyList<EnumDto> Enums { get; init; }
}
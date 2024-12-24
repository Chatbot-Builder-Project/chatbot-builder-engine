using ChatbotBuilderEngine.Application.Graphs.Enums;
using ChatbotBuilderEngine.Application.Graphs.Links.DataLinks;
using ChatbotBuilderEngine.Application.Graphs.Links.FlowLinks;
using ChatbotBuilderEngine.Application.Graphs.Nodes;

namespace ChatbotBuilderEngine.Application.Graphs;

public sealed record GraphDto(
    int StartNodeIdentifier,
    IReadOnlyList<NodeDto> Nodes,
    IReadOnlyList<DataLinkDto> DataLinks,
    IReadOnlyList<FlowLinkDto> FlowLinks,
    IReadOnlyList<EnumDto> Enums);
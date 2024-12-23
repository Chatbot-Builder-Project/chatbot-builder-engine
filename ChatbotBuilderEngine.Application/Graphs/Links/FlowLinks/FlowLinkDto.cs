using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Links.FlowLinks;

public sealed record FlowLinkDto(
    InfoMeta Info,
    VisualMeta Visual,
    int InputNodeIdentifier,
    int OutputNodeIdentifier
) : LinkDto(Info, Visual);
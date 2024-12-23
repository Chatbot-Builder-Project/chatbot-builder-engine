using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Links.DataLinks;

public sealed record DataLinkDto(
    InfoMeta Info,
    VisualMeta Visual,
    int InputPortIdentifier,
    int OutputPortIdentifier
) : LinkDto(Info, Visual);
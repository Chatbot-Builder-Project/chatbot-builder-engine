using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Links;

public abstract record LinkDto(
    InfoMeta Info,
    VisualMeta Visual);
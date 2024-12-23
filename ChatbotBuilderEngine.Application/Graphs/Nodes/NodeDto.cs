using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes;

public abstract record NodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    NodeType Type
);
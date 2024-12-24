using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Ports;

public abstract record PortDto(
    InfoMeta Info,
    VisualMeta Visual,
    PortDirection Direction,
    int NodeIdentifier);
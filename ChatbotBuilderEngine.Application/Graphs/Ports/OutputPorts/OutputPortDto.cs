using ChatbotBuilderEngine.Application.Graphs.Shared.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Ports.OutputPorts;

public sealed record OutputPortDto(
    InfoMeta Info,
    VisualMeta Visual,
    PortDirection Direction,
    DataType DataType
) : PortDto(Info, Visual, Direction);
using ChatbotBuilderEngine.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderEngine.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Interaction;

public sealed record InteractionNodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    NodeType Type,
    InputPortDto? TextInputPort,
    OutputPortDto? TextOutputPort,
    int? OutputEnumIdentifier,
    OutputPortDto? OptionOutputPort,
    IReadOnlyDictionary<OptionData, InteractionOptionMeta>? OutputOptionMetas
) : NodeDto(Info, Visual, Type);
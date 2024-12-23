using ChatbotBuilderEngine.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderEngine.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Prompt;

public sealed record PromptNodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    NodeType Type,
    PromptTemplateDto Template,
    OutputPortDto OutputPort,
    IReadOnlyList<InputPortDto> InputPorts
) : NodeDto(Info, Visual, Type);
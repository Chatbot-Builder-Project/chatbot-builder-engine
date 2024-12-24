using ChatbotBuilderEngine.Application.Graphs.Nodes.Abstract;
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
) : NodeDto(Info, Visual, Type),
    IInputNodeDto, IEnumNodeDto, IOutputNodeDto
{
    public IEnumerable<int> GetInputPortIds()
    {
        if (TextOutputPort is not null)
        {
            yield return TextOutputPort.Info.Identifier;
        }
    }

    public IEnumerable<int> GetEnumIds()
    {
        if (OutputEnumIdentifier is not null)
        {
            yield return OutputEnumIdentifier.Value;
        }
    }

    public IEnumerable<int> GetOutputPortIds()
    {
        if (TextOutputPort is not null)
        {
            yield return TextOutputPort.Info.Identifier;
        }

        if (OptionOutputPort is not null)
        {
            yield return OptionOutputPort.Info.Identifier;
        }
    }
}
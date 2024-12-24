using ChatbotBuilderEngine.Application.Graphs.Nodes.Abstract;
using ChatbotBuilderEngine.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Switch;

public sealed record SwitchNodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    NodeType Type,
    InputPortDto InputPort,
    int EnumIdentifier,
    IReadOnlyDictionary<OptionData, int> Bindings
) : NodeDto(Info, Visual, Type),
    IInputNodeDto, IEnumNodeDto, ISwitchNodeDto
{
    public IEnumerable<int> GetInputPortIds()
    {
        yield return InputPort.Info.Identifier;
    }

    public IEnumerable<int> GetEnumIds()
    {
        yield return EnumIdentifier;
    }

    public IEnumerable<int> GetFlowLinkIds()
    {
        return Bindings.Values;
    }
}
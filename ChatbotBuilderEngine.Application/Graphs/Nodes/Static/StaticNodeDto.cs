using ChatbotBuilderEngine.Application.Graphs.Nodes.Abstract;
using ChatbotBuilderEngine.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderEngine.Application.Graphs.Shared.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Static;

public sealed record StaticNodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    NodeType Type,
    DataType DataType,
    Data Data,
    OutputPortDto OutputPort
) : NodeDto(Info, Visual, Type),
    IOutputNodeDto
{
    public IEnumerable<int> GetOutputPortIds()
    {
        yield return OutputPort.Info.Identifier;
    }
}